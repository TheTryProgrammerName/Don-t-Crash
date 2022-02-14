using UnityEngine;
using System.Collections;

public class PositionTracker : MonoBehaviour
{
    [SerializeField] private GameObject _startLine, _post1, _post2;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private PostController _postController;

    private int _recordPoint = -6, _startLineOffPoint = -15;
    private float _postTeleportationPointFrom = -38f;
    private float _postSpasing = 27f;

    public bool CharacterIsAlive { set; private get; } = true;

    public void start()
    {
        StartCoroutine(PostTrack(_post1));
        StartCoroutine(PostTrack(_post2));
        StartCoroutine(TapToStartTrack());
    }

    public void reset()
    {
        StopAllCoroutines();

        _startLine.SetActive(true);
    }

    private IEnumerator PostTrack(GameObject Post)
    {
        Transform PostTransform = Post.transform;

        _postController.GeneratePost(Post);

        while (CharacterIsAlive)
        {
            while (PostTransform.position.x > _recordPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _scoreUpdater.UpdateScore();

            while (PostTransform.position.x > _postTeleportationPointFrom)
            {
                yield return new WaitForFixedUpdate();
            }

            float teleportTo;

            if (PostTransform.position.x < _post1.transform.position.x)
            {
                teleportTo = _post1.transform.position.x + _postSpasing;
            }
            else
            {
                teleportTo = _post2.transform.position.x + _postSpasing;
            }

            PostTransform.position = new Vector2(teleportTo, PostTransform.position.y);

            StartCoroutine(PostTrack(Post));

            yield break;
        }

        yield break;
    }

    private IEnumerator TapToStartTrack()
    {
        Transform StartLineTransform = _startLine.transform;

        while (CharacterIsAlive)
        {
            while (StartLineTransform.position.x > _startLineOffPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _startLine.SetActive(false);

            yield break;
        }

        yield break;
    }
}
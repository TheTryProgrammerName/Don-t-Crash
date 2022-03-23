using UnityEngine;
using System.Collections;

public class PositionTracker : MonoBehaviour
{
    [SerializeField] private GameObject _startLine, _post1, _post2;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private PostController _postController;

    private int _character—ollisionWithPostPoint = -3, _recordPoint = -6, _startLineOffPoint = -15;
    private float _postBehindTheScreenPoint = 13.3f;
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
        ObjectsGroup GroundShadowOverlapGroup = Post.GetComponent<ObjectsGroup>();

        while (CharacterIsAlive)
        {
            while (PostTransform.position.x >= _postBehindTheScreenPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _postController.GeneratePost(Post);

            while (PostTransform.position.x >= _character—ollisionWithPostPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            GroundShadowOverlapGroup.Disable();

            while (PostTransform.position.x >= _recordPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _scoreUpdater.AddScore();

            while (PostTransform.position.x >= _postTeleportationPointFrom)
            {
                yield return new WaitForFixedUpdate();
            }

            GameObject nextPost = getNextPost();
            float teleportTo = nextPost.transform.position.x + _postSpasing;
            PostTransform.position = new Vector2(teleportTo, PostTransform.position.y);

            GroundShadowOverlapGroup.Enable();

            StartCoroutine(PostTrack(Post));

            yield break;
        }

        yield break;
    }

    private GameObject getNextPost()
    {
        if (_post1.transform.position.x > _post2.transform.position.x)
        {
            return _post1;
        }
        else
        {
            return _post2;
        }
    }

    private IEnumerator TapToStartTrack()
    {
        Transform StartLineTransform = _startLine.transform;

        while (CharacterIsAlive)
        {
            while (StartLineTransform.position.x >= _startLineOffPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _startLine.SetActive(false);

            yield break;
        }

        yield break;
    }
}
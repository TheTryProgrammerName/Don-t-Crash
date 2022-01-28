using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PositionTracker : MonoBehaviour
{
    [SerializeField] private GameObject _startLine, _post1, _post2;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private PostController _postController;
    [SerializeField] private IsometricCorrector _isometricCorrector;

    private Utilits utilits;

    private Vector2 _postTeleportPosition = new Vector2(14, 0.75f);
    private List<Vector2> PostCubesPositions;

    private int characterBeforePostPoint = -3, _recordPoint = -6, _postTeleportationPoint = -38, _startLineOffPoint = -15;

    public bool CharacterIsAlive { set; private get; } = true;

    public void Initialize()
    {
        utilits = new Utilits();
        PostCubesPositions = new List<Vector2>();

        Queue<GameObject> postCubes = utilits.GetChildrenQueue(_post1);

        int postCubesCount = postCubes.Count;

        for (int i = 0; i < postCubesCount; i++)
        {
            PostCubesPositions.Add(postCubes.Dequeue().transform.position);
        }

        PostCubesPositions.Reverse();
    }

    public void start()
    {
        StartCoroutine(PostTrack(_post1));
        StartCoroutine(PostTrack(_post2));
        StartCoroutine(TapToStartTrack());
        StartCoroutine(CharacterTrack());
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
            _isometricCorrector.isCharacterBeforePost = true;
            _isometricCorrector.changeCharacterSortingOrder(100);

            while (PostTransform.position.x > characterBeforePostPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _isometricCorrector.isCharacterBeforePost = false;

            _isometricCorrector.changeCharacterSortingOrder(3);

            while (PostTransform.position.x > _recordPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _scoreUpdater.UpdateScore();

            while (PostTransform.position.x > _postTeleportationPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            PostTransform.position = _postTeleportPosition;

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

    private IEnumerator CharacterTrack()
    {
        int UpperCubeNumber = 1;
        bool isValueChanged = false;
        Vector2 UpperCubePosition = PostCubesPositions[UpperCubeNumber];

        while (CharacterIsAlive)
        {
            if (_characterTransform.position.y > UpperCubePosition.y && UpperCubeNumber < PostCubesPositions.Count - 1)
            {
                UpperCubeNumber++;
                isValueChanged = true;
            }

            if (_characterTransform.position.y < UpperCubePosition.y && UpperCubeNumber > 1)
            {
                UpperCubeNumber--;
                isValueChanged = true;
            }

            if (isValueChanged)
            {
                UpperCubePosition = PostCubesPositions[UpperCubeNumber];
                _isometricCorrector.updateCharacterSortingOrder(UpperCubeNumber);
                isValueChanged = false;
            }

            yield return new WaitForFixedUpdate();
        }

        yield break;
    }
}
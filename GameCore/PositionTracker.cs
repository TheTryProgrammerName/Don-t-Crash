using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PositionTracker : MonoBehaviour, IAbility
{
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private PostsController _postsController;
    [SerializeField] private ScreenSizeGetter _screenSizeGetter;
    [SerializeField] private ObjectsPool _postsPool;

    [SerializeField] private GameObject _startLine;

    [SerializeField] private Transform _startLineTransform;

    private Transform[] _postsTransform;
    private ObjectsPool[] _groundShadowOverlapGroup;

    private Dictionary<int, GameObject[]> _postsCubes;

    private const float _character—ollisionWithPostDefaultPoint = -3;
    private const float _character—ollisionWithPostAbilityPoint = -3.875f;
    private const float _startLineWidth = 4.8f;
    private const float _postWidth = 3.5f;
    private const float _postBehindTheScreenPointAdd = 0.3f;
    private const float _postTeleportationPointFrom = -38f;
    private const float _postSpasing = 27f;

    private float _character—ollisionWithPostPoint;
    private float _startLineOffPoint;
    private float _postBehindTheScreenPoint;

    private const int _recordPoint = -6;

    public bool CharacterIsAlive { set; private get; } = true;

    private Utilits _utilits;

    public void Initialize()
    {
        _scoreUpdater.Initialize();

        _utilits = new Utilits();

        _postsTransform = new Transform[_postsPool.ObjectsCount];
        _groundShadowOverlapGroup = new ObjectsPool[_postsPool.ObjectsCount];
        _postsCubes = new Dictionary<int, GameObject[]>();

        for (int i = 0; i < _postsPool.ObjectsCount; i++)
        {
            _postsTransform[i] = _postsPool.Objects[i].transform;
            _groundShadowOverlapGroup[i] = _postsPool.Objects[i].GetComponent<ObjectsPool>();
            Queue <GameObject> postCubes = _utilits.GetChildrenQueue(_postsTransform[i]);
            _postsCubes.Add(i, postCubes.ToArray());
        }

        _character—ollisionWithPostPoint = _character—ollisionWithPostDefaultPoint;

        Vector2 screenSize = _screenSizeGetter.GetScreenSize();
        float leftScreenEdge = screenSize.x;
        float rightScreenEdge = screenSize.x * -1;
        _startLineOffPoint = leftScreenEdge - _startLineWidth / 2;
        _postBehindTheScreenPoint = rightScreenEdge + _postWidth / 2 + _postBehindTheScreenPointAdd;
    }

    public void start()
    {
        for (int i = 0; i < _postsPool.ObjectsCount; i++)
        {
            StartCoroutine(PostTrack(i));
        }

        StartCoroutine(TapToStartTrack());

        _scoreUpdater.start();
    }

    public void reset()
    {
        StopAllCoroutines();

        _startLine.SetActive(true);

        foreach (ObjectsPool GroundShadowOverlapGroup in _groundShadowOverlapGroup)
        {
            GroundShadowOverlapGroup.Enable();
        }

        _scoreUpdater.reset();
    }

    public void ApplyAbility()
    {
        _character—ollisionWithPostPoint = _character—ollisionWithPostAbilityPoint;
    }

    public void DissapplyAbility()
    {
        _character—ollisionWithPostPoint = _character—ollisionWithPostDefaultPoint;
    }

    private IEnumerator PostTrack(int postIndex)
    {
        while (CharacterIsAlive)
        {
            while (_postsTransform[postIndex].localPosition.x >= _postBehindTheScreenPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _postsController.GeneratePost(_postsCubes[postIndex]);

            while (_postsTransform[postIndex].localPosition.x >= _character—ollisionWithPostPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _groundShadowOverlapGroup[postIndex].Disable();

            while (_postsTransform[postIndex].localPosition.x >= _recordPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _scoreUpdater.AddScore();

            while (_postsTransform[postIndex].localPosition.x >= _postTeleportationPointFrom)
            {
                yield return new WaitForFixedUpdate();
            }

            int nextPostIndex = getNextPost();;
            float teleportTo = _postsTransform[nextPostIndex].localPosition.x + _postSpasing;
            _postsTransform[postIndex].localPosition = new Vector2(teleportTo, _postsTransform[postIndex].localPosition.y);

            _groundShadowOverlapGroup[postIndex].Disable();

            StartCoroutine(PostTrack(postIndex));

            yield break;
        }

        yield break;
    }

    //¬ÓÁ‚‡˘‡ÂÚ ÒÚÓÎ· Ò Ò‡ÏÓÈ ·ÓÎ¸¯ÓÈ ÔÓÁËˆËÂÈ
    private int getNextPost()
    {
        float biggestPosition = _postsPool.Objects[0].transform.localPosition.x;
        int postWithBiggestPositionIndex = 0;

        for (int i = 1; i < _postsPool.ObjectsCount; i++)
        {
            if (_postsTransform[i].localPosition.x > biggestPosition)
            {
                biggestPosition = _postsTransform[i].localPosition.x;
                postWithBiggestPositionIndex = i;
            }
        }

        return postWithBiggestPositionIndex;
    }

    private IEnumerator TapToStartTrack()
    {
        while (CharacterIsAlive)
        {
            while (_startLineTransform.localPosition.x >= _startLineOffPoint)
            {
                yield return new WaitForFixedUpdate();
            }

            _startLine.SetActive(false);

            yield break;
        }

        yield break;
    }
}
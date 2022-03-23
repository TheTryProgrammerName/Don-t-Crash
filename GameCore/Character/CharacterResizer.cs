using UnityEngine;
using System.Collections.Generic;

public class CharacterResizer : MonoBehaviour
{
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private Transform _groundShadowTransform;

    [SerializeField] private SpriteRenderer[] _post1LeftShadows;
    [SerializeField] private SpriteRenderer[] _post1TopShadows;
    [SerializeField] private SpriteRenderer[] _post2LeftShadows;
    [SerializeField] private SpriteRenderer[] _post2TopShadows;

    [SerializeField] private Sprite _postLeftShadowsMax;
    [SerializeField] private Sprite _postTopShadowsMax;
    [SerializeField] private Sprite _postLeftShadowsMin;
    [SerializeField] private Sprite _postTopShadowsMin;

    private List<Transform> _post1LeftShadowsTransforms;
    private List<Transform> _post1TopShadowsTransforms;
    private List<Transform> _post2LeftShadowsTransforms;
    private List<Transform> _post2TopShadowsTransforms;

    private Vector2 _characterMinSize = new Vector2(0.5f, 0.5f);
    private Vector2 _groundShadowMinSize = new Vector2(0.5f, 0.25f);
    private Vector2 _groundShadowMaxSize = new Vector2(0.5f, 0.5f);

    private Vector2 _groundShadowMinSizePosition = new Vector2(4.25f, -12.755f);
    private Vector2 _groundShadowMaxSizePosition = new Vector2(4.25f, -12.5f);

    private Vector2 _postLeftShadowPositionMax = new Vector2(-3f, 0f);
    private Vector2 _postLeftShadowPositionMin = new Vector2(-2.75f, -0.25f);

    private Vector2 _postTopShadowPositionMax = new Vector2(0f, 3f);
    private Vector2 _postTopShadowPositionMin = new Vector2(0.25f, 2.75f);

    public void Initialize()
    {
        _post1LeftShadowsTransforms = new List<Transform>();
        _post1TopShadowsTransforms = new List<Transform>();
        _post2LeftShadowsTransforms = new List<Transform>();
        _post2TopShadowsTransforms = new List<Transform>();

        for (int i = 0; i < _post1LeftShadows.Length - 1; i++)
        {
            _post1LeftShadowsTransforms.Add(_post1LeftShadows[i].transform);
            _post2LeftShadowsTransforms.Add(_post2LeftShadows[i].transform);
        }

        for (int i = 0; i < _post1TopShadows.Length - 1; i++)
        {
            _post1TopShadowsTransforms.Add(_post1TopShadows[i].transform);
            _post2TopShadowsTransforms.Add(_post2TopShadows[i].transform);
        }
    }

    public void resizeMin()
    {
        _characterTransform.localScale = _characterMinSize;
        _groundShadowTransform.localScale = _groundShadowMinSize;

        _groundShadowTransform.position = _groundShadowMinSizePosition;

        for (int i = 0; i < _post1LeftShadows.Length - 1; i++)
        {
            _post1LeftShadows[i].sprite = _postLeftShadowsMin;
            _post2LeftShadows[i].sprite = _postLeftShadowsMin;

            _post1LeftShadowsTransforms[i].localPosition = _postLeftShadowPositionMin;
            _post2LeftShadowsTransforms[i].localPosition = _postLeftShadowPositionMin;
        }

        for (int i = 0; i < _post1TopShadows.Length - 1; i++)
        {
            _post1TopShadows[i].sprite = _postTopShadowsMin;
            _post2TopShadows[i].sprite = _postTopShadowsMin;

            _post1TopShadowsTransforms[i].localPosition = _postTopShadowPositionMin;
            _post2TopShadowsTransforms[i].localPosition = _postTopShadowPositionMin;
        }
    }

    public void resizeMax()
    {
        _characterTransform.localScale = Vector2.one;
        _groundShadowTransform.localScale = _groundShadowMaxSize;

        _groundShadowTransform.position = _groundShadowMaxSizePosition;

        for (int i = 0; i < _post1LeftShadows.Length - 1; i++)
        {
            _post1LeftShadows[i].sprite = _postLeftShadowsMax;
            _post2LeftShadows[i].sprite = _postLeftShadowsMax;

            _post1LeftShadowsTransforms[i].localPosition = _postLeftShadowPositionMax;
            _post2LeftShadowsTransforms[i].localPosition = _postLeftShadowPositionMax;
        }

        for (int i = 0; i < _post1TopShadows.Length - 1; i++)
        {
            _post1TopShadows[i].sprite = _postTopShadowsMax;
            _post2TopShadows[i].sprite = _postTopShadowsMax;

            _post1TopShadowsTransforms[i].localPosition = _postTopShadowPositionMax;
            _post2TopShadowsTransforms[i].localPosition = _postTopShadowPositionMax;
        }
    }
}

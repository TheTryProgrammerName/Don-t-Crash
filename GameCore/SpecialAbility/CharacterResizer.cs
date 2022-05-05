using UnityEngine;

public class CharacterResizer : MonoBehaviour
{
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private Transform _groundShadowTransform;

    [SerializeField] private SpriteRenderer[] _postsLeftShadows;
    [SerializeField] private SpriteRenderer[] _postsTopShadows;

    [SerializeField] private Sprite _leftShadowSprite;
    [SerializeField] private Sprite _topShadowSprite;

    [SerializeField] private Vector2 _characterSize;
    [SerializeField] private Vector2 _groundShadowSize;
    [SerializeField] private Vector2 _groundShadowPosition;
    [SerializeField] private Vector2 _postLeftShadowPosition;
    [SerializeField] private Vector2 _postTopShadowPosition;

    private Transform[] _postsLeftShadowsTransforms;
    private Transform[] _postsTopShadowsTransforms;

    public void Initialize()
    {
        _postsLeftShadowsTransforms = new Transform[_postsLeftShadows.Length];
        _postsTopShadowsTransforms = new Transform[_postsTopShadows.Length];

        for (int i = 0; i < _postsLeftShadows.Length - 1; i++)
        {
            _postsLeftShadowsTransforms[i] = _postsLeftShadows[i].transform;
        }

        for (int i = 0; i < _postsTopShadows.Length - 1; i++)
        {
            _postsTopShadowsTransforms[i] = _postsTopShadows[i].transform;
        }
    }

    public void Apply()
    {
        _characterTransform.localScale = _characterSize;
        _groundShadowTransform.localScale = _groundShadowSize;

        _groundShadowTransform.localPosition = _groundShadowPosition;

        for (int i = 0; i < _postsLeftShadows.Length - 1; i++)
        {
            _postsLeftShadows[i].sprite = _leftShadowSprite;

            _postsLeftShadowsTransforms[i].localPosition = _postLeftShadowPosition;
        }

        for (int i = 0; i < _postsTopShadows.Length - 1; i++)
        {
            _postsTopShadows[i].sprite = _topShadowSprite;

            _postsTopShadowsTransforms[i].localPosition = _postTopShadowPosition;
        }
    }
}
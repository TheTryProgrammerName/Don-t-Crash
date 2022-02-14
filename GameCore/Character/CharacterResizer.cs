using UnityEngine;

public class CharacterResizer : MonoBehaviour
{
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private Transform _characterShadowTransform;

    private Vector3 _characterMinSize = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 _shadowMinSize = new Vector3(0.25f, 0.25f, 1.0f);
    private Vector3 _shadowMaxSize = new Vector3(0.5f, 0.5f, 1.0f);

    private float _characterMinSizeStartPositionY = -12.125f;
    private float _characterMaxSizeStartPositionY = -11.255f;

    private float _shadowMinSizeStartPositionX = -4.625f;
    private float _shadowMaxSizeStartPositionX = -3.25f;
    private float _shadowMinSizeStartPositionY = -12.75f;
    private float _shadowMaxSizeStartPositionY = -12.505f;

    public void resizeMin()
    {
        _characterTransform.localScale = _characterMinSize;
        _characterShadowTransform.localScale = _shadowMinSize;
        _characterShadowTransform.position = new Vector2(_shadowMinSizeStartPositionX + _characterTransform.position.y - _characterMinSizeStartPositionY, _shadowMinSizeStartPositionY);
    }

    public void resizeMax()
    {
        _characterTransform.localScale = Vector2.one;
        _characterShadowTransform.localScale = _shadowMaxSize;
        _characterShadowTransform.position = new Vector2(_shadowMaxSizeStartPositionX + _characterTransform.position.y - _characterMaxSizeStartPositionY, _shadowMaxSizeStartPositionY);
    }
}

using UnityEngine;

public class CharacterResizer : MonoBehaviour
{
    [SerializeField] private Transform _character;
    [SerializeField] private Transform _characterShadow;

    private Vector3 _characterMinSize = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 _shadowMinSize = new Vector3(0.25f, 0.25f, 1.0f);
    private Vector3 _shadowMaxSize = new Vector3(0.5f, 0.5f, 1.0f);

    public void resizeMin()
    {
        _character.localScale = _characterMinSize;
        _characterShadow.localScale = _shadowMinSize;
    }

    public void resizeMax()
    {
        _character.localScale = Vector2.one;
        _characterShadow.localScale = _shadowMaxSize;
    }
}

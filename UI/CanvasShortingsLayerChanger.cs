using UnityEngine;

public class CanvasShortingsLayerChanger : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    public void ChangeShortingsLayer(string sortingLayer)
    {
        _canvas.sortingLayerName = sortingLayer;
    }
}

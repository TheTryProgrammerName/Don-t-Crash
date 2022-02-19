using UnityEngine;

public class CanvasShortingsOrderChanger : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    public void ChangeShortingsOrder(int shortingOrder)
    {
        _canvas.sortingOrder = shortingOrder;
    }
}

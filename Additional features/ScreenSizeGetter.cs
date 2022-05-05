using UnityEngine;

public class ScreenSizeGetter : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    public Vector2 GetScreenSize()
    {
        Vector2 screenSize = _mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, _mainCamera.farClipPlane));

        return screenSize;
    }
}

using UnityEngine;

public class CameraDepthChanger : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public void ChangeDepth(int depth)
    {
        _camera.depth = depth;
    }
}

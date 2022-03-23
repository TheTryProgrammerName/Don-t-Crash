using UnityEngine;

public class ObjectsGroup : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;

    public void Enable()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].SetActive(true);
        }
    }

    public void Disable()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].SetActive(false);
        }
    }
}

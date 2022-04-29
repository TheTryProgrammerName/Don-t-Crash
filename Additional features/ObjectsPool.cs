using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    public GameObject[] Objects;
    public int ObjectsCount { get; private set; }

    public void Initialize()
    {
        ObjectsCount = Objects.Length;
    }

    public void Enable()
    {
        foreach (GameObject enabledObject in Objects)
        {
            enabledObject.SetActive(true);
        }
    }

    public void Disable()
    {
        foreach (GameObject disabledObject in Objects)
        {
            disabledObject.SetActive(false);
        }
    }
}

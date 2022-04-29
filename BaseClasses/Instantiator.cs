using System.Collections.Generic;
using UnityEngine;

public abstract class Instantiator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    [SerializeField] protected RectTransform _container;

    protected List<GameObject> _instantiateObjects;

    protected void CreateObject()
    {
        GameObject instantiateText = Instantiate(_prefab, _container);
        _instantiateObjects.Add(instantiateText);
    }

    protected void DestroyObject()
    {
        Destroy(_instantiateObjects[0]);
        _instantiateObjects.RemoveAt(0);
    }
}

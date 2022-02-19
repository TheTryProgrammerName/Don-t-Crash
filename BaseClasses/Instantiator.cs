using System.Collections.Generic;
using UnityEngine;

public abstract class Instantiator : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _prefab;

    public List<GameObject> _instantiateObjects;

    public void CreateObject()
    {
        GameObject instantiateText = Instantiate(_prefab, _container);
        _instantiateObjects.Add(instantiateText);
    }

    public void DestroyObject()
    {
        Destroy(_instantiateObjects[0]);
        _instantiateObjects.RemoveAt(0);
    }
}

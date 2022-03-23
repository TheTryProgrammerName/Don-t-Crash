using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugInfoDrawer : Instantiator
{
    public void Initialize()
    {
        _instantiateObjects = new List<GameObject>();
    }

    public void onSwitchHandleGroup(int groupInfoCount)
    {
        if (_instantiateObjects.Count < groupInfoCount)
        {
            int needCreateTextCount = groupInfoCount - _instantiateObjects.Count;

            for (int i = 0; i < needCreateTextCount; i++)
            {
                CreateObject();
            }
        }

        if (_instantiateObjects.Count > groupInfoCount)
        {
            int needDestroyTextCount = _instantiateObjects.Count - groupInfoCount;

            for (int i = 0; i < needDestroyTextCount; i++)
            {
                DestroyObject();
            }
        }
    }

    public void DrawInfo(DebugGroup debugGroup)
    {
        List<Info> info = debugGroup.Info;
        int InfoCount = info.Count;

        for (int i = 0; i < InfoCount; i++)
        {
            _instantiateObjects[i].GetComponent<TextMeshProUGUI>().text = info[i].Name + info[i].Value;
        }
    }

    public void DestroyAll()
    {
        int instantiateObjectsCount = _instantiateObjects.Count;

        for (int i = 0; i < instantiateObjectsCount; i++)
        {
            DestroyObject();
        }
    }
}

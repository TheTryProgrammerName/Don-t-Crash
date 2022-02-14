using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugInfoDrawer : MonoBehaviour
{
    [SerializeField] private Transform _textContainer;
    [SerializeField] private GameObject _textPrefab;

    private List<GameObject> _InstantiateTextList;

    public void Initialize()
    {
        _InstantiateTextList = new List<GameObject>();
    }

    public void onSwitchHandleGroup(int groupInfoCount)
    {
        if (_InstantiateTextList.Count < groupInfoCount)
        {
            int needCreateTextCount = groupInfoCount - _InstantiateTextList.Count;

            for (int i = 0; i < needCreateTextCount; i++)
            {
                CreateTextObject();
            }
        }

        if (_InstantiateTextList.Count > groupInfoCount)
        {
            int needDestroyTextCount = _InstantiateTextList.Count - groupInfoCount;

            for (int i = 0; i < needDestroyTextCount; i++)
            {
                DestroyTextObject();
            }
        }
    }

    public void DrawInfo(DebugGroup debugGroup)
    {
        List<Info> info = debugGroup.Info;
        int InfoCount = info.Count;

        for (int i = 0; i < InfoCount; i++)
        {
            _InstantiateTextList[i].GetComponent<TextMeshProUGUI>().text = info[i].Name + info[i].Value;
        }
    }

    public void CreateTextObject()
    {
        GameObject instantiateText = Instantiate(_textPrefab, _textContainer);
        _InstantiateTextList.Add(instantiateText);
    }

    public void DestroyTextObject()
    {
        Destroy(_InstantiateTextList[0]);
        _InstantiateTextList.RemoveAt(0);
    }
}

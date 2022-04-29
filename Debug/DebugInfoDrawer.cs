using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugInfoDrawer : Instantiator
{
    private List<TextMeshProUGUI> _text;

    public void Initialize()
    {
        _instantiateObjects = new List<GameObject>();
        _text = new List<TextMeshProUGUI>();
    }

    public void DrawInfo(Dictionary<string, object> info)
    {
        createOrDestroy(_text.Count, info.Count);

        int i = 0;

        foreach (KeyValuePair<string, object> keyValuePair in info)
        {
            string formatedText = string.Format("{0}: {1}", keyValuePair.Key, keyValuePair.Value);
            _text[i].text = formatedText;
            i++;
        }
    }

    private void createOrDestroy(int curentCount, int needCount)
    {
        if (curentCount < needCount)
        {
            for (int i = curentCount; i < needCount; i++)
            {
                CreateObject();
                _text.Add(_instantiateObjects[i].GetComponent<TextMeshProUGUI>());
            }
        }

        if (curentCount > needCount)
        {
            for (int i = curentCount; i > needCount; i--)
            {
                DestroyObject();
                _text.RemoveAt(0);
            }
        }
    }

    public void DestroyAll()
    {
        foreach (GameObject destroyblObject in _instantiateObjects)
        {
            Destroy(destroyblObject);
        }

        _instantiateObjects.Clear();
    }
}
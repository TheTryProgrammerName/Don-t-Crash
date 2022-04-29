using UnityEngine;
using TMPro;

public class TextSwitcher : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Switch(string text)
    {
        _text.text = text;
    }
}
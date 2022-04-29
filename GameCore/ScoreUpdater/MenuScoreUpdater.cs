using UnityEngine;
using TMPro;

public class MenuScoreUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordText;

    private const int _textMaxWidth = 500;

    private SaveData _saveData;

    public void Initialize()
    {
        _saveData = new SaveData();
        int Record = _saveData.LoadInt("Record");
        UpdateRecord(Record);
    }

    public void UpdateRecord(int record)
    {
        _recordText.text = record.ToString();
        _recordText.autoSizeTextContainer = false;

        if (_recordText.preferredWidth < _textMaxWidth) //Если контейнер не больше лемита
        {
            _recordText.autoSizeTextContainer = true; //Подгоняем его размеры под размеры текста
        }                                             //Иначе подгоняем текст под размеры контейнера (в эдиторе галочка стоит)
    }
}

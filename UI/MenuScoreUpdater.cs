using UnityEngine;
using TMPro;

public class MenuScoreUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordText;

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
        _recordText.autoSizeTextContainer = true;
    }
}

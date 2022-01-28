using UnityEngine;
using TMPro;

public class MenuScoreUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordText;

    private SaveData _saveData;

    public void Initialize()
    {
        _saveData = new SaveData();
        _recordText.text = _saveData.LoadInt("Record").ToString();
    }

    public void UpdateRecord(int record)
    {
        _recordText.text = record.ToString();
    }
}

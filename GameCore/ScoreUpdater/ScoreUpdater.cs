using UnityEngine;
using UnityEngine.Events;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private ScoreTextDraver _scoreTextDraver;
    [SerializeField] private MenuScoreUpdater _menuScoreUpdater;
    [SerializeField] private UnityEvent<float> _sendScoreCoef;

    private SaveData _saveData = new SaveData();

    private int _score = 0;

    public float ScoreCoef;
    public float MinScoreCoef = 1.0f, AddScoreCoefForRecord = 0.05f;

    public void Initialize()
    {
        ScoreCoef = MinScoreCoef;
        _scoreTextDraver.DrawScoreText(_score);
    }

    public void start()
    {
        sendScore();
    }

    public void UpdateScore()
    {
        _score++;
        CalculateRecordCoef();

        sendScore();
        _scoreTextDraver.DrawScoreText(_score);
    }

    private void CalculateRecordCoef()
    {
        if (ScoreCoef < MinScoreCoef)
        {
            ScoreCoef = MinScoreCoef;
        }
        else
        {
            ScoreCoef = MinScoreCoef + _score * AddScoreCoefForRecord;
        }
    }

    public void sendScore()
    {
        _sendScoreCoef.Invoke(ScoreCoef);
    }

    public void SaveScore()
    {
        int Record = _saveData.LoadInt("Record");

        if (Record < _score)
        {
            _saveData.SaveInt("Record", _score);
            _menuScoreUpdater.UpdateRecord(_score);
        }
    }

    public void reset()
    {
        SaveScore();

        _scoreTextDraver.reset();

        _score = 0;
        ScoreCoef = MinScoreCoef;
        sendScore();
    }
}
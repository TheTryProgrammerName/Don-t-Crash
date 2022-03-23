using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private ScoreTextDraver _scoreTextDraver;
    [SerializeField] private MenuScoreUpdater _menuScoreUpdater;
    [SerializeField] private UIController _UIcontroller;

    private SaveData _saveData = new SaveData();

    private int _score = 0;

    public void start()
    {
        UpdateScore();
    }

    public void AddScore()
    {
        _score++;

        UpdateScore();
    }

    private void UpdateScore()
    {
        _scoreTextDraver.DrawScoreText(_score);
    }

    public void SaveScore()
    {
        int Record = _saveData.LoadInt("Record");

        if (Record < _score)
        {
            _saveData.SaveInt("Record", _score);
            _menuScoreUpdater.UpdateRecord(_score);
            _UIcontroller.SetPreset("NewRecord");
        }
    }

    public void reset()
    {
        SaveScore();

        _scoreTextDraver.reset();

        _score = 0;
    }
}
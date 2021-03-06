using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private ScoreTextDraver _scoreTextDraver;
    [SerializeField] private MenuScoreUpdater _menuScoreUpdater;
    [SerializeField] private UIController _UIcontroller;

    private SaveData _saveData = new SaveData();

    private int _score = 0;

    public void Initialize()
    {
        _scoreTextDraver.Initialize();
        _menuScoreUpdater.Initialize();
    }

    public void start()
    {
        DrawScore();
    }

    public void AddScore()
    {
        _score++;

        DrawScore();
    }

    private void DrawScore()
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
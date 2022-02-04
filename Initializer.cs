using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private DebugUIController _debugUIController;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private MenuScoreUpdater _menuScoreUpdater;
    [SerializeField] private PostController _postController;
    [SerializeField] private PostGenerator _postGenerator;
    [SerializeField] private DeveloperSettings _developerSettings;
    [SerializeField] private SpeedChanger _speedChanger;
    [SerializeField] private PositionTracker _positionTracker;

    private void Awake()
    {
        _debugUIController.Initialize();
        _menuScoreUpdater.Initialize();
        _scoreUpdater.Initialize();
        _postController.Initialize();
        _postGenerator.Initialize();
        _developerSettings.Initizlize();
        _speedChanger.Initialize();
        _positionTracker.Initialize();

        Destroy(this);
    }
}

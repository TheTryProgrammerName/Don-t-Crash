using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private DebugInfoHandler _debugInfoHandler;
    [SerializeField] private Mover _mover;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private MenuScoreUpdater _menuScoreUpdater;
    [SerializeField] private PostController _postController;
    [SerializeField] private PostGenerator _postGenerator;
    [SerializeField] private DeveloperSettings _developerSettings;
    [SerializeField] private DebugInfoDrawer _debugInfoDrawer;
    [SerializeField] private DebugUIController _debugUIController;

    private void Awake()
    {
        _debugInfoHandler.Initialize();
        _mover.Initialize();
        _menuScoreUpdater.Initialize();
        _scoreUpdater.Initialize();
        _postController.Initialize();
        _postGenerator.Initialize();
        _developerSettings.Initizlize();
        _debugInfoDrawer.Initialize();
        _debugUIController.Initialize();

        Destroy(this);
    }
}

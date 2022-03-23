using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private DebugInfoHandler _debugInfoHandler;
    [SerializeField] private Mover _mover;
    [SerializeField] private ScoreTextDraver _scoreTextDraver;
    [SerializeField] private MenuScoreUpdater _menuScoreUpdater;
    [SerializeField] private PostController _postController;
    [SerializeField] private PostGenerator _postGenerator;
    [SerializeField] private DeveloperSettings _developerSettings;
    [SerializeField] private DebugInfoDrawer _debugInfoDrawer;
    [SerializeField] private DebugUIController _debugUIController;
    [SerializeField] private CharacterResizer _characterResizer;

    private UIFadeout[] _UIFadeouts;

    private void Awake()
    {
        _UIFadeouts = FindObjectsOfType<UIFadeout>();

        _debugInfoHandler.Initialize();
        _mover.Initialize();
        _menuScoreUpdater.Initialize();
        _scoreTextDraver.Initialize();
        _postController.Initialize();
        _postGenerator.Initialize();
        _developerSettings.Initizlize();
        _debugInfoDrawer.Initialize();
        _debugUIController.Initialize();

        int UIFadeoutsLenght = _UIFadeouts.Length;

      //  for (int i = 0; i < UIFadeoutsLenght; i++)
        {
            _UIFadeouts[0].Initialize();
        }

        _characterResizer.Initialize();

        Destroy(this);
    }
}

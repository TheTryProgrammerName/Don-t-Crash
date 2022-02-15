using UnityEngine;

public class GameConditions : MonoBehaviour
{
    [SerializeField] private GameObject _gameCore;
    [SerializeField] private Character _character;
    [SerializeField] private Mover _mover;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private PositionTracker _positionTracker;
    [SerializeField] private PostController _postController;
    [SerializeField] private PostGenerator _postGenerator;
    [SerializeField] private CharacterControl _characterControl;

    public void start()
    {
        _gameCore.SetActive(true);

        _character.start();
        _scoreUpdater.start();
        _positionTracker.start();
        _postController.start();
    }

    public void reset()
    {
        _mover.reset();
        _scoreUpdater.reset();
        _positionTracker.reset();
        _postController.reset();
        _postGenerator.reset();
    }

    public void pause()
    {
        _characterControl.enabled = false;
        _mover.pause();
    }

    public void unPause()
    {
        _characterControl.enabled = true;
        _mover.unPause();
    }
}
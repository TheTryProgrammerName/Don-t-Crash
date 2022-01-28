using UnityEngine;

public class GameConditions : MonoBehaviour
{
    [SerializeField] private GameObject _gameCore;
    [SerializeField] private GraphicsMover _graphicsMover;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private PositionTracker _positionTracker;
    [SerializeField] private PostController _postController;
    [SerializeField] private PostGenerator _postGenerator;
    [SerializeField] private Character _character;
    [SerializeField] private SpeedChanger _speedChanger;

    public void start()
    {
        _gameCore.SetActive(true);

        _character.start();
        _graphicsMover.start();
        _scoreUpdater.start();
        _positionTracker.start();
        _postController.start();
        _speedChanger.start();
    }

    public void reset()
    {
        _character.reset();
        _graphicsMover.reset();
        _scoreUpdater.reset();
        _positionTracker.reset();
        _postController.reset();
        _postGenerator.reset();
        _speedChanger.reset();
    }

    public void pause()
    {
        _character.pause();
        _graphicsMover.pause();
        _speedChanger.pause();
    }

    public void unPause()
    {
        _character.unPause();
        _graphicsMover.unPause();
        _speedChanger.unPause();
    }
}
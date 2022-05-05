using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private SpeedChanger _speedChanger;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private GraphicsMover _graphicsMover;

    private bool _isPause;

    public bool characterIsAlive { private get; set; }

    public void Initialize()
    {
        _speedChanger.Initialize();
        _graphicsMover.Initialize();
    }

    public void reset()
    {
        _speedChanger.reset();
        _characterMover.reset();
        _graphicsMover.reset();
    }

    public void pause()
    {
        _isPause = true;
        _characterMover.pause();
        _graphicsMover.pause();
    }

    public void unPause()
    {
        _isPause = false;
        _characterMover.unPause();
    }

    public void ChangeCharacterDirectionUp()
    {
        _characterMover.ChangeDirectionUp();
    }

    public void ChangeCharacterDirectionDown()
    {
        _characterMover.ChangeDirectionDown();
    }

    private void FixedUpdate()
    {
        if (!_isPause && characterIsAlive)
        {
            _speedChanger.ChangeSpeed();

            _characterMover.Move();
            _graphicsMover.Move();
        }
    }
}
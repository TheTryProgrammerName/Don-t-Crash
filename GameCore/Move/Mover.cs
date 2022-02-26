using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private SpeedChanger _speedChanger;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private GraphicsMover _graphicsMover;

    [SerializeField] private CharacterResizer _characterResizer;
    [SerializeField] private TimerController _timerController;

    [SerializeField] private Rigidbody2D _characterRigidbody;

    private bool _isPause;
    private bool _isFastFly;

    private float _timeToNormolize = 2f, _timeSpeedBoost = 6f;
    private float _timeScaleBeforeBoost;

    public bool characterIsAlive { private get; set; }

    public void Initialize()
    {
        _speedChanger.Initialize();
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

    private void FixedUpdate()
    {
        if (!_isPause && characterIsAlive)
        {
            _speedChanger.ChangeSpeed();

            _characterMover.Move();
            _graphicsMover.Move();
        }
    }

    public void FastFly()
    {
        if (!_isFastFly)
        {
            _characterRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _characterResizer.resizeMin();

            _speedChanger.MaxSpeed = _speedChanger.MaxSpeed * _timeSpeedBoost;
            _timeScaleBeforeBoost = Time.timeScale;
            Time.timeScale = Time.timeScale * _timeSpeedBoost;

            Timer TimerToNormolaze = _timerController.SetTimer(_timeToNormolize);
            StartCoroutine(CheckTimerTime(TimerToNormolaze));
            _isFastFly = true;
        }
    }

    private void Normolaze()
    {
        _characterResizer.resizeMax();
        _characterRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        Time.timeScale = _timeScaleBeforeBoost + Time.timeScale - _timeScaleBeforeBoost * _timeSpeedBoost;

        _isFastFly = false;
    }

    private IEnumerator CheckTimerTime(Timer timer)
    {
        while (characterIsAlive && timer.TTime > 0)
        {
            yield return new WaitForFixedUpdate();

            if (_isPause)
            {
                timer.TTime += Time.fixedDeltaTime;
            }
        }

        Destroy(timer.gameObject);
        Normolaze();

        yield break;
    }
}

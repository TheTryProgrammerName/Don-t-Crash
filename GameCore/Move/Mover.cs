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

    private DebugInfoSender _debugInfoSender;
    private Timer _timer;

    private bool _isPause;
    private bool _isFastFly;

    private float _timeToNormolize = 2f, _timeSpeedBoost = 6f;
    private float _timeScaleBeforeBoost;

    public bool characterIsAlive { private get; set; }

    public void Initialize()
    {
        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();

        _timer = _timerController.CreateTimer();

        _speedChanger.Initialize();
    }

    private void InitializeDebug()
    {
        _debugInfoSender.RegisterInfo("Mover", "FastFlyTime: ");
    }

    public void reset()
    {
        if (_isFastFly)
        {
            Normolaze();
            StopAllCoroutines();
            _timer.TimerTime = 0;
            _debugInfoSender.SendInfo("Mover", "FastFlyTime: ", _timer.TimerTime);
        }

        _speedChanger.reset();
        _characterMover.reset();
        _graphicsMover.reset();
    }

    public void pause()
    {
        _isPause = true;
        _characterMover.pause();
        _graphicsMover.pause();
        _timer.pause();
    }

    public void unPause()
    {
        _isPause = false;
        _characterMover.unPause();
        _timer.play();
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

    private void BoostSpeed()
    {
        _timeScaleBeforeBoost = Time.timeScale;
        Time.timeScale = Time.timeScale * _timeSpeedBoost;
    }

    private void ResetBoostSpeed()
    {
        Time.timeScale = _timeScaleBeforeBoost + Time.timeScale - _timeScaleBeforeBoost * _timeSpeedBoost;
    }

    public void FastFly()
    {
        if (!_isFastFly)
        {
            _characterRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _characterResizer.resizeMin();

            _speedChanger.MaxSpeed = _speedChanger.MaxSpeed * _timeSpeedBoost;
            BoostSpeed();

            _timer.SetTime(_timeToNormolize);
            _timer.play();
            StartCoroutine(CheckTimerTime());
            _isFastFly = true;
        }
    }

    private void Normolaze()
    {
        _characterResizer.resizeMax();
        _characterRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        _speedChanger.MaxSpeed = _speedChanger.MaxSpeed / _timeSpeedBoost;
        _isFastFly = false;
    }

    private IEnumerator CheckTimerTime()
    {
        while (characterIsAlive && _timer.TimerTime > 0)
        {
            yield return new WaitForFixedUpdate();

            _debugInfoSender.SendInfo("Mover", "FastFlyTime: ", _timer.TimerTime);
        }

        Normolaze();
        ResetBoostSpeed();

        yield break;
    }
}

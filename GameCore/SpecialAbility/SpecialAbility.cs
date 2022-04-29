using System.Collections;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    [SerializeField] private TimerInstantiator _timerInstantiator;
    [SerializeField] private CharacterResizer _characterSizeMax;
    [SerializeField] private CharacterResizer _characterSizeMin;

    [SerializeField] private SpeedChanger _speedChanger;

    [SerializeField] private Rigidbody2D _characterRigidbody;

    private DebugInfoSender _debugInfoSender;
    private Timer _timer;

    private float _timeToNormolize = 2f, _timeSpeedBoost = 6f;
    private float _timeScaleBeforeBoost;

    private bool _isActive;
    public bool characterIsAlive { private get; set; }

    public void Initialize()
    {
        _characterSizeMax.Initialize();
        _characterSizeMin.Initialize();

        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();

        _timer = _timerInstantiator.InstantiateTimer();
    }

    private void InitializeDebug()
    {
        _debugInfoSender.SendInfo("SpecialAbility", "TimeLeft", 0);
    }

    public void reset()
    {
        if (_isActive)
        {
            Normolaze();
            StopAllCoroutines();
            _timer.time = 0;
            _debugInfoSender.SendInfo("SpecialAbility", "TimeLeft", _timer.time);
        }
    }

    public void pause()
    {
        _timer.pause();
    }

    public void unPause()
    {
        _timer.play();
    }

    public void Apply()
    {
        if (!_isActive)
        {
            _characterRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _characterSizeMin.Apply();

            _speedChanger.MaxSpeed = _speedChanger.MaxSpeed * _timeSpeedBoost;
            _timeScaleBeforeBoost = Time.timeScale;
            Time.timeScale = Time.timeScale * _timeSpeedBoost;

            _timer.SetTime(_timeToNormolize);
            _timer.play();

            StartCoroutine(CheckTimerTime());

            _isActive = true;
        }
    }

    private void Normolaze()
    {
        _characterSizeMax.Apply();
        _characterRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        _speedChanger.MaxSpeed = _speedChanger.MaxSpeed / _timeSpeedBoost;
        _isActive = false;
    }

    private IEnumerator CheckTimerTime()
    {
        while (characterIsAlive && _timer.time > 0)
        {
            yield return new WaitForFixedUpdate();

            _debugInfoSender.SendInfo("Mover", "FastFlyTime", _timer.time);
        }

        Normolaze();
        Time.timeScale = _timeScaleBeforeBoost + Time.timeScale - _timeScaleBeforeBoost * _timeSpeedBoost;

        yield break;
    }
}

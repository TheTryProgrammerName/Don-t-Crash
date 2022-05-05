using System.Collections;
using System.Linq;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    [SerializeField] private TimerInstantiator _timerInstantiator;
    [SerializeField] private CharacterResizer _characterSizeMax;
    [SerializeField] private CharacterResizer _characterSizeMin;

    [SerializeField] private Rigidbody2D _characterRigidbody;

    private DebugInfoSender _debugInfoSender;
    private Timer _timer;

    private IAbility[] _IAbilitys;

    private const float _timeToDissaply = 2f;

    public bool isActive;
    public bool characterIsAlive { private get; set; }

    public void Initialize()
    {
        _characterSizeMax.Initialize();
        _characterSizeMin.Initialize();

        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();

        _timer = _timerInstantiator.InstantiateTimer();

        _IAbilitys = FindObjectsOfType<MonoBehaviour>().OfType<IAbility>().ToArray();
    }

    private void InitializeDebug()
    {
        _debugInfoSender.SendInfo("SpecialAbility", "TimeLeft", 0);
    }

    public void reset()
    {
        if (isActive)
        {
            Dissaply();
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
        if (!isActive)
        {
            _characterRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

            _characterSizeMin.Apply();

            foreach (IAbility iAbility in _IAbilitys)
            {
                iAbility.ApplyAbility();
            }

            _timer.setTime(_timeToDissaply);
            _timer.play();

            StartCoroutine(CheckTimerTime());

            isActive = true;
        }
        else
        {
            _timer.setTime(_timeToDissaply);
        }
    }

    private void Dissaply()
    {
        _characterSizeMax.Apply();

        foreach (IAbility iAbility in _IAbilitys)
        {
            iAbility.DissapplyAbility();
        }

        _characterRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        isActive = false;
    }

    private IEnumerator CheckTimerTime()
    {
        while (characterIsAlive && _timer.time > 0)
        {
            yield return new WaitForFixedUpdate();

            _debugInfoSender.SendInfo("SpecialAbility", "TimeLeft", _timer.time);
        }

        Dissaply();

        yield break;
    }
}

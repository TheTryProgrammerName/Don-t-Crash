using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterControl _characterControl;
    [SerializeField] private CharacterResizer _characterResizer;

    [SerializeField] private UnityEvent _death;
    [SerializeField] private UnityEvent _alive;

    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private TimerController _timerController;

    private Vector2 _startPosition = new Vector2(-6, -11.255f);
    private Vector2 _direction;
    private Vector2 _vectorSpeed;

    private bool _characterIsAlive;

    private float _timeToNormolize = 1.6f, _timeSpeedBoost = 6f, _normalTimeSpeed = 1f;

    private bool isPause;

    public bool Immortality;
    public float GameSpeed { private get; set; }
    public int Speed = 60;

    public void start()
    {
        Alive();
        StartCoroutine(Move());
    }

    public void reset()
    {
        StopAllCoroutines();

        Normolaze();

        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;

        _direction = -transform.up;
    }

    public void pause()
    {
        isPause = true;

        _characterControl.enabled = false;

        _rigidbody.simulated = false;
    }

    public void unPause()
    {
        isPause = false;

        _characterControl.enabled = true;

        _rigidbody.simulated = true;
    }

    public void MoveUp()
    {
        _direction = transform.up;
    }

    public void MoveDown()
    {
        _direction = -transform.up;
    }

    private IEnumerator Move()
    {
        while (_characterIsAlive)
        {
            _vectorSpeed = _direction * Speed * GameSpeed * Time.fixedDeltaTime;
            _rigidbody.AddForce(_vectorSpeed);

            yield return new WaitForFixedUpdate();
        }

        yield break;
    }

    public void FastFly()
    {
        _characterControl.lockControl = true;

        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        _characterResizer.resizeMin();
        Time.timeScale = _timeSpeedBoost;

        Timer TimerToNormolaze = _timerController.SetTimer(_timeToNormolize / GameSpeed);

        StartCoroutine(CheckTimerTime(TimerToNormolaze));
    }

    private void Normolaze()
    {
        _characterControl.lockControl = false;

        _characterResizer.resizeMax();

        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        Time.timeScale = _normalTimeSpeed;
    }

    private IEnumerator CheckTimerTime(Timer timer)
    {
        while (_characterIsAlive)
        {
            while (timer.TTime > 0)
            {
                yield return new WaitForFixedUpdate();

                if (isPause)
                {
                    timer.TTime += Time.fixedDeltaTime;
                }
            }

            Destroy(timer.gameObject);
             
            Normolaze();

            yield break;
        }

        yield break;
    }

    private void Alive()
    {
        _characterIsAlive = true;
        _alive.Invoke();
    }

    private void Death()
    {
        _characterIsAlive = false;
        _death.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!Immortality)
        {
            Death();
        }
    }
}
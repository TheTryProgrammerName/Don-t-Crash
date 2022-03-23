using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private GameObject _timerPrefab;
    private GameObject _timerObject;

    public Timer CreateTimer()
    {
        _timerObject = Instantiate(_timerPrefab);
        Timer _timer = _timerObject.GetComponent<Timer>();

        return _timer;
    }
}

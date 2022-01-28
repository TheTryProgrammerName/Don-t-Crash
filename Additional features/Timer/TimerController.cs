using UnityEngine;

//Просто создаёт один таймер и делает с ним всякое
//При необходимости будет модифицирован для управления кучей таймеров
public class TimerController : MonoBehaviour
{
    [SerializeField] private GameObject _timerPrefab;
    private GameObject _timerObject;

    public Timer SetTimer(float time)
    {
        CreateTimer();
        Timer _timer = _timerObject.GetComponent<Timer>();
        _timer.SetTimer(time);
        _timer.play();

        return _timer;
    }

    public void StopTimer(Timer timer)
    {
        timer.pause();
    }

    public void PlayTimer(Timer timer)
    {
        timer.play();
    }

    private void CreateTimer()
    {
        _timerObject = Instantiate(_timerPrefab);
    }
}

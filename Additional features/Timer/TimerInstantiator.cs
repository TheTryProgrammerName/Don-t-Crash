using UnityEngine;

public class TimerInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject _timerPrefab;

    public Timer InstantiateTimer()
    {
        GameObject timerObject = Instantiate(_timerPrefab);
        Timer timer = timerObject.GetComponent<Timer>();

        return timer;
    }
}

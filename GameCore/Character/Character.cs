using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private UnityEvent _death;
    [SerializeField] private UnityEvent _alive;

    public bool Immortality;

    public void start()
    {
        _alive.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!Immortality)
        {
            _death.Invoke();
        }
    }
}
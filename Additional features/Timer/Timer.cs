using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TimerTime;
    private bool isPause = true;

    public void pause()
    {
        isPause = true;
    }

    public void play()
    {
        isPause = false;
    }

    public void SetTime(float time)
    {
        TimerTime = time;
    }

    private void FixedUpdate()
    {
        if (!isPause)
        {
            if (TimerTime <= 0)
            {
                isPause = true;
            }

            TimerTime = TimerTime - Time.fixedDeltaTime;
        }
    }
}

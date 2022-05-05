using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;

    private bool _isPause = true;

    public void pause()
    {
        _isPause = true;
    }

    public void play()
    {
        _isPause = false;
    }

    public void setTime(float time)
    {
        this.time = time;
    }

    private void FixedUpdate()
    {
        if (!_isPause)
        {
            time = time - Time.fixedDeltaTime;

            if (time <= 0)
            {
                _isPause = true;
            }
        }
    }
}

using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TTime;
    public bool isPause;

    public void pause()
    {
        isPause = true;
    }

    public void play()
    {
        isPause = false;
    }

    public void SetTimer(float time)
    {
        TTime = time;
    }

    private void FixedUpdate()
    {
        if (!isPause)
        {
            TTime = TTime - Time.fixedDeltaTime;
        }
    }
}

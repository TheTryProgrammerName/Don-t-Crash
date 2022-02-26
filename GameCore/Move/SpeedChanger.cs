using UnityEngine;

//Отвечает за скорость игры
public class SpeedChanger : MonoBehaviour
{
    private DebugInfoSender _debugInfoSender;

    public float MaxSpeed = 6.0f;
    public float MinSpeed = 1.0f;

    public float SpeedForFrame = 0.0001f; //Прибавление скорости за кадр

    public void Initialize()
    {
        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();

        Time.timeScale = MinSpeed;
    }

    private void InitializeDebug()
    {
        _debugInfoSender.InitializeInfo("SpeedChanger", "CurrentSpeed: ");
        _debugInfoSender.InitializeInfo("SpeedChanger", "SpeedForFrame: ");
    }

    public void reset()
    {
        Time.timeScale = MinSpeed;

        StopAllCoroutines();
    }

    public void ChangeSpeed()
    {
        if (Time.timeScale <= MaxSpeed && Time.timeScale >= MinSpeed)
        {
            Time.timeScale += SpeedForFrame;
            _debugInfoSender.SendInfo("SpeedChanger", "CurrentSpeed: ", Time.timeScale.ToString("0.0000"));
            _debugInfoSender.SendInfo("SpeedChanger", "SpeedForFrame: ", SpeedForFrame.ToString("0.0000"));
        }
    }
}

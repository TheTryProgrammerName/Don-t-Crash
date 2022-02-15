using UnityEngine;

//Отвечает за скорость игры
public class SpeedChanger : MonoBehaviour
{
    private DebugInfoSender _debugInfoSender;

    public float CurrentSpeed;
    public float MaxSpeed = 60.0f;
    public float MinSpeed = 10.0f;

    public float SpeedForFrame = 0.001f; //Прибавление скорости за кадр

    public void Initialize()
    {
        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();

        CurrentSpeed = MinSpeed;
    }

    private void InitializeDebug()
    {
        _debugInfoSender.InitializeInfo("SpeedChanger", "CurrentSpeed: ");
        _debugInfoSender.InitializeInfo("SpeedChanger", "SpeedForFrame: ");
    }

    public void reset()
    {
        CurrentSpeed = MinSpeed;

        StopAllCoroutines();
    }

    public void ChangeSpeed()
    {
        if (CurrentSpeed <= MaxSpeed && CurrentSpeed >= MinSpeed)
        {
            CurrentSpeed += SpeedForFrame;

            _debugInfoSender.SendInfo("SpeedChanger", "CurrentSpeed: ", CurrentSpeed.ToString("0.0000"));
            _debugInfoSender.SendInfo("SpeedChanger", "SpeedForFrame: ", SpeedForFrame.ToString("0.0000"));
        }
    }
}

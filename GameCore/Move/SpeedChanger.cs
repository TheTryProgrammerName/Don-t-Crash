using UnityEngine;

//Отвечает за скорость игры
public class SpeedChanger : MonoBehaviour
{
    private DebugInfoSender _debugInfoSender;

    public float MaxSpeed = 3.0f;
    public float MinSpeed = 1.0f;

    public float SpeedForFrame = 0.0001f; //Прибавление скорости за кадр
    public float SpeedChangeFactor = 0.4f;

    public void Initialize()
    {
        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();

        Time.timeScale = MinSpeed;
    }

    private void InitializeDebug()
    {
        _debugInfoSender.RegisterInfo("SpeedChanger", "CurrentSpeed: ");
        _debugInfoSender.RegisterInfo("SpeedChanger", "SpeedForFrame: ");
        _debugInfoSender.RegisterInfo("SpeedChanger", "SpeedChangeFactor: ");
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
            Time.timeScale += SpeedForFrame * SpeedChangeFactor;
            _debugInfoSender.SendInfo("SpeedChanger", "CurrentSpeed: ", Time.timeScale.ToString("0.0000"));
            _debugInfoSender.SendInfo("SpeedChanger", "SpeedForFrame: ", SpeedForFrame.ToString("0.0000"));
            _debugInfoSender.SendInfo("SpeedChanger", "SpeedChangeFactor: ", SpeedChangeFactor.ToString("0.0"));
        }
    }
}

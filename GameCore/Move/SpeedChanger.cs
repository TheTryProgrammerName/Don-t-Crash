using UnityEngine;

//Отвечает за скорость игры
public class SpeedChanger : MonoBehaviour, IAbility
{
    private DebugInfoSender _debugInfoSender;

    private const float _timeBoostCoef = 6f;
    private const float _exponentLowLimit = 0.2f;

    private float _exponent;
    private float _exponentDevider;

    public float MaxSpeed = 3.0f;
    public float MinSpeed = 1.0f;

    public float SpeedForFrame = 0.0001f; //Прибавление скорости за кадр
    public float SpeedChangeFactor = 0.4f; //Модификатор на который умножается SpeedForFrame

    public void Initialize()
    {
        _debugInfoSender = new DebugInfoSender();
        InitializeDebug();

        Time.timeScale = MinSpeed;

        CalculateExponentDevider();
    }

    private void InitializeDebug()
    {
        _debugInfoSender.SendInfo("SpeedChanger", "CurrentSpeed", 0);
        _debugInfoSender.SendInfo("SpeedChanger", "SpeedForFrame", 0);
        _debugInfoSender.SendInfo("SpeedChanger", "SpeedChangeFactor", 0);
        _debugInfoSender.SendInfo("SpeedChanger", "Exponent", 0);
    }

    public void reset()
    {
        Time.timeScale = MinSpeed;
    }

    public void ApplyAbility()
    {
        MaxSpeed = MaxSpeed * _timeBoostCoef;
        MinSpeed = MinSpeed * _timeBoostCoef;
        SpeedForFrame = SpeedForFrame * _timeBoostCoef;

        Time.timeScale = Time.timeScale * _timeBoostCoef;

        _exponentDevider = _exponentDevider * _timeBoostCoef;
    }

    public void DissapplyAbility()
    {
        MaxSpeed = MaxSpeed / _timeBoostCoef;
        MinSpeed = MinSpeed / _timeBoostCoef;
        SpeedForFrame = SpeedForFrame / _timeBoostCoef;

        Time.timeScale = Time.timeScale / _timeBoostCoef;

        _exponentDevider = _exponentDevider / _timeBoostCoef;
    }

    public void CalculateExponentDevider()
    {
        _exponentDevider = MaxSpeed - MinSpeed;
    }

    public void ChangeSpeed()
    {
        if (Time.timeScale <= MaxSpeed && Time.timeScale >= MinSpeed)
        {
            if (_exponent > _exponentLowLimit)
            {
                _exponent = (MaxSpeed - Time.timeScale) / _exponentDevider;
            }

            Time.timeScale += SpeedForFrame * SpeedChangeFactor * _exponent;

            _debugInfoSender.SendInfo("SpeedChanger", "CurrentSpeed", Time.timeScale.ToString("0.0000"));
            _debugInfoSender.SendInfo("SpeedChanger", "SpeedForFrame", SpeedForFrame.ToString("0.0000"));
            _debugInfoSender.SendInfo("SpeedChanger", "SpeedChangeFactor", SpeedChangeFactor.ToString("0.0"));
            _debugInfoSender.SendInfo("SpeedChanger", "Exponent", _exponent.ToString("0.000"));
        }
    }
}

using System.Collections;
using UnityEngine;

//Отвечает за скорость игры
public class SpeedChanger : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private GraphicsMover _graphicsMover;

    private DebugInfoSender _debugInfoSender;

    public float CurrentSpeed;
    public float MaxSpeed = 6.0f;
    public float MinSpeed = 1.0f;
    private bool _isPause;

    public float SpeedForFrame = 0.0001f; //Прибавление скорости за кадр
    public bool CharacterIsAlive { set; private get; }

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

    public void start()
    {
        StartCoroutine(ChangeSpeed());
    }

    public void reset()
    {
        CurrentSpeed = MinSpeed;

        StopAllCoroutines();
    }

    public void pause()
    {
        _isPause = true;
    }

    public void unPause()
    {
        _isPause = false;
    }

    private IEnumerator ChangeSpeed()
    {
        while (CharacterIsAlive)
        {
            yield return new WaitForFixedUpdate();

            if (!_isPause && CurrentSpeed <= MaxSpeed && CurrentSpeed >= MinSpeed)
            {
                CurrentSpeed += SpeedForFrame;
                _character.GameSpeed = CurrentSpeed;
                _graphicsMover.GameSpeed = CurrentSpeed;
            }

            _debugInfoSender.SendInfo("SpeedChanger", "CurrentSpeed: ", CurrentSpeed.ToString("0.0000"));
            _debugInfoSender.SendInfo("SpeedChanger", "SpeedForFrame: ", SpeedForFrame.ToString("0.0000"));
        }

        yield break;
    }
}

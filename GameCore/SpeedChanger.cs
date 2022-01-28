using System.Collections;
using UnityEngine;
using TMPro;

//Отвечает за скорость игры
public class SpeedChanger : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private GraphicsMover _graphicsMover;

    [SerializeField] private TextMeshProUGUI _currentSpeedText;
    [SerializeField] private TextMeshProUGUI _SpeedForFrameText;

    public float CurrentSpeed;
    public float MaxSpeed = 6.0f;
    public float MinSpeed = 1.0f;
    private bool _isPause;

    public float SpeedForFrame = 0.0002f; //Прибавление скорости за кадр
    public bool CharacterIsAlive { set; private get; }

    public void Initialize()
    {
        CurrentSpeed = MinSpeed;
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

            _currentSpeedText.text = "CurrentSpeed: " + CurrentSpeed.ToString("0.0000");
            _SpeedForFrameText.text = "SpeedForFrame: " + SpeedForFrame.ToString("0.0000");
        }

        yield break;
    }
}

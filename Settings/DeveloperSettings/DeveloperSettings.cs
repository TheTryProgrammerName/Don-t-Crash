using UnityEngine;
using TMPro;

public class DeveloperSettings : MonoBehaviour
{
    [SerializeField] private DebugUIController _debugUIController;
    [SerializeField] private DebugInfoDrawer _debugInfoDrawer;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private GraphicsMover _graphicsMover;
    [SerializeField] private Character _character;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private SpeedChanger _speedChanger;
    [SerializeField] private UIController _UIController;
    [SerializeField] private DebugInfoHandler _debugInfoHandler;
    [SerializeField] private PostGenerator _postGenerator;

    [SerializeField] private Rigidbody2D _characterRB;

    [SerializeField] private TextMeshProUGUI _immortalityCondition;
    [SerializeField] private TextMeshProUGUI _postSpeedCondition;
    [SerializeField] private TextMeshProUGUI _characterSpeedCondition;
    [SerializeField] private TextMeshProUGUI _startGameSpeedCondition;
    [SerializeField] private TextMeshProUGUI _currentGameSpeedCondition;
    [SerializeField] private TextMeshProUGUI _maxGameSpeedCondition;
    [SerializeField] private TextMeshProUGUI _addGameSpeedForFrameCondition;
    [SerializeField] private TextMeshProUGUI _addGameSpeedForFrameFactorCondition;
    [SerializeField] private TextMeshProUGUI _difficultCoefForGenerationCondition;
    [SerializeField] private TextMeshProUGUI _characterMassCondition;
    [SerializeField] private TextMeshProUGUI _characterAngularDragCondition;
    [SerializeField] private TextMeshProUGUI _characterGravityCondition;
    [SerializeField] private TextMeshProUGUI _debugModeCondition;

    private Utilits _utilits;

    private string _On = "Вкл";
    private string _Off = "Выкл";

    public void Initizlize()
    {
        _immortalityCondition.text = _Off;
        _debugModeCondition.text = _Off;
        _utilits = new Utilits();
    }

    public void UpdateConditions()
    {
        _postSpeedCondition.text = _graphicsMover.GraphicsSpeed.ToString("0");
        _characterSpeedCondition.text = _characterMover.CharacterSpeed.ToString("0");
        _startGameSpeedCondition.text = _speedChanger.MinSpeed.ToString("0.00");
        _currentGameSpeedCondition.text = Time.timeScale.ToString("0.00");
        _maxGameSpeedCondition.text = _speedChanger.MaxSpeed.ToString("0.00");
        _addGameSpeedForFrameCondition.text = _speedChanger.SpeedForFrame.ToString("0.0000");
        _addGameSpeedForFrameFactorCondition.text = _speedChanger.SpeedChangeFactor.ToString("0.0");
        _difficultCoefForGenerationCondition.text = _postGenerator.AddDifficultCoefForGeneration.ToString("0.000");
        _characterMassCondition.text = _characterRB.mass.ToString("0.00");
        _characterAngularDragCondition.text = _characterRB.angularDrag.ToString("0.00");
        _characterGravityCondition.text = _characterRB.gravityScale.ToString("0.00");
    }

    public void EnableImmortality(bool condition)
    {
        condition = _utilits.LoopBoolValue(_character.Immortality, condition);

        _character.Immortality = condition;

        if (condition == true)
        {
            _immortalityCondition.text = _On;
        }
        else
        {
            _immortalityCondition.text = _Off;
        }
    }

    public void ChangeGraphicsSpeed(float NewSpeed)
    {
        _graphicsMover.GraphicsSpeed = _graphicsMover.GraphicsSpeed + NewSpeed;
        _postSpeedCondition.text = _graphicsMover.GraphicsSpeed.ToString("0");
    }

    public void ChangeCharacterSpeed(float NewSpeed)
    {
        _characterMover.CharacterSpeed = _characterMover.CharacterSpeed + NewSpeed;
        _characterSpeedCondition.text = _characterMover.CharacterSpeed.ToString("0");
    }

    public void ChangeStartGameSpeed(float NewSpeed)
    {
        _speedChanger.MinSpeed = _speedChanger.MinSpeed + NewSpeed;

        _speedChanger.MinSpeed = _utilits.CheckFloatHighLimit(_speedChanger.MinSpeed, _speedChanger.MaxSpeed);

        _startGameSpeedCondition.text = _speedChanger.MinSpeed.ToString("0.00");
    }

    public void ChangeCurrentGameSpeed(float NewSpeed)
    {
        Time.timeScale = Time.timeScale + NewSpeed;

        Time.timeScale = _utilits.CheckFloatHighLimit(Time.timeScale, _speedChanger.MaxSpeed);
        Time.timeScale = _utilits.CheckFloatLowLimit(Time.timeScale, _speedChanger.MinSpeed);

        _currentGameSpeedCondition.text = Time.timeScale.ToString("0.00");
    }

    public void ChangeMaxGameSpeed(float NewSpeed)
    {
        _speedChanger.MaxSpeed = _speedChanger.MaxSpeed + NewSpeed;

        _speedChanger.MaxSpeed = _utilits.CheckFloatLowLimit(_speedChanger.MaxSpeed, Time.timeScale);

        _maxGameSpeedCondition.text = _speedChanger.MaxSpeed.ToString("0.00");
    }

    public void ChangeSpeedForFrame(float NewSpeed)
    {
        _speedChanger.SpeedForFrame = _speedChanger.SpeedForFrame + NewSpeed;

        _addGameSpeedForFrameCondition.text = _speedChanger.SpeedForFrame.ToString("0.0000");
    }

    public void ChangeSpeedForFrameFactor(float NewFactor)
    {
        _speedChanger.SpeedChangeFactor = _speedChanger.SpeedChangeFactor + NewFactor;

        _addGameSpeedForFrameFactorCondition.text = _speedChanger.SpeedChangeFactor.ToString("0.0");
    }

    public void ChangeDifficultCoefForGeneration(float NewValue)
    {
        _postGenerator.AddDifficultCoefForGeneration = _postGenerator.AddDifficultCoefForGeneration + NewValue;

        _difficultCoefForGenerationCondition.text = _postGenerator.AddDifficultCoefForGeneration.ToString("0.000");
    }

    public void ChangeCharacterMass(float NewValue)
    {
        _characterRB.mass = _characterRB.mass + NewValue;

        _characterMassCondition.text = _characterRB.mass.ToString("0.00");
    }

    public void ChangeCharacterAngularDrag(float NewValue)
    {
        _characterRB.angularDrag = _characterRB.angularDrag + NewValue;

        _characterAngularDragCondition.text = _characterRB.angularDrag.ToString("0.00");
    }

    public void ChangeCharacterGravity(float NewValue)
    {
        _characterRB.gravityScale = _characterRB.gravityScale + NewValue;

        _characterGravityCondition.text = _characterRB.gravityScale.ToString("0.00");
    }

    public void EnableDebugMode(bool condition)
    {
        condition = _utilits.LoopBoolValue(_debugUIController.enabled, condition);

        if (condition == true)
        {
            _UIController.SetPreset("Debug");
            _debugInfoHandler.handle = true;
            _debugUIController.enabled = true;
            _debugModeCondition.text = _On;
            _debugUIController.SwitchHandleGroup(0);
        }
        else
        {
            _UIController.SetInvertPreset("Debug");
            _debugInfoHandler.handle = false;
            _debugUIController.enabled = false;
            _debugModeCondition.text = _Off;
            _debugInfoDrawer.DestroyAll();
        }
    }
}
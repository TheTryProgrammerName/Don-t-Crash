using UnityEngine;
using TMPro;

public class DeveloperSettings : MonoBehaviour
{
    [SerializeField] private DebugGroupSwitcher _debugGroupSwitcher;
    [SerializeField] private DebugInfoDrawer _debugInfoDrawer;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private GraphicsMover _graphicsMover;
    [SerializeField] private Character _character;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private SpeedChanger _speedChanger;
    [SerializeField] private UIController _UIController;
    [SerializeField] private DebugInfoHandler _debugInfoHandler;
    [SerializeField] private PostsController _postsController;
    [SerializeField] private SpecialAbility _specialAbility;

    [SerializeField] private Rigidbody2D _characterRB;

    [SerializeField] private TextMeshProUGUI _immortalityCondition;
    [SerializeField] private TextMeshProUGUI _postSpeedCondition;
    [SerializeField] private TextMeshProUGUI _characterSpeedCondition;
    [SerializeField] private TextMeshProUGUI _minGameSpeedCondition;
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

    private const string _On = "Вкл";
    private const string _Off = "Выкл";

    private const float _timeScaleMinValue = 0.1f;

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
        _minGameSpeedCondition.text = _speedChanger.MinSpeed.ToString("0.00");
        _currentGameSpeedCondition.text = Time.timeScale.ToString("0.00");
        _maxGameSpeedCondition.text = _speedChanger.MaxSpeed.ToString("0.00");
        _addGameSpeedForFrameCondition.text = _speedChanger.SpeedForFrame.ToString("0.0000");
        _addGameSpeedForFrameFactorCondition.text = _speedChanger.SpeedChangeFactor.ToString("0.0");
        _difficultCoefForGenerationCondition.text = _postsController.AddDifficultCoefForGeneration.ToString("0.000");
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

    public void ChangeGraphicsSpeed(float newSpeed)
    {
        _graphicsMover.GraphicsSpeed = _graphicsMover.GraphicsSpeed + newSpeed;
        _postSpeedCondition.text = _graphicsMover.GraphicsSpeed.ToString("0");
    }

    public void ChangeCharacterSpeed(float newSpeed)
    {
        _characterMover.CharacterSpeed = _characterMover.CharacterSpeed + newSpeed;
        _characterSpeedCondition.text = _characterMover.CharacterSpeed.ToString("0");
    }

    public void ChangeStartGameSpeed(float newSpeed)
    {
        if (!_specialAbility.isActive)
        {
            float minSpeed = _speedChanger.MinSpeed + newSpeed;

            minSpeed = _utilits.CheckFloatHighLimit(minSpeed, Time.timeScale);
            minSpeed = _utilits.CheckFloatLowLimit(minSpeed, _timeScaleMinValue);

            _speedChanger.MinSpeed = minSpeed;
            _speedChanger.CalculateExponentDevider();

            _minGameSpeedCondition.text = minSpeed.ToString("0.00");
        }
    }

    public void ChangeCurrentGameSpeed(float newSpeed)
    {
        if (!_specialAbility.isActive)
        {
            float timeScale = Time.timeScale + newSpeed;

            timeScale = _utilits.CheckFloatHighLimit(timeScale, _speedChanger.MaxSpeed);
            timeScale = _utilits.CheckFloatLowLimit(timeScale, _speedChanger.MinSpeed);

            Time.timeScale = timeScale;

            _currentGameSpeedCondition.text = timeScale.ToString("0.00");
        }
    }

    public void ChangeMaxGameSpeed(float newSpeed)
    {
        if (!_specialAbility.isActive)
        {
            float maxSpeed = _speedChanger.MaxSpeed + newSpeed;

            maxSpeed = _utilits.CheckFloatLowLimit(maxSpeed, Time.timeScale);

            _speedChanger.MaxSpeed = maxSpeed;
            _speedChanger.CalculateExponentDevider();

            _maxGameSpeedCondition.text = maxSpeed.ToString("0.00");
        }
    }

    public void ChangeSpeedForFrame(float newSpeed)
    {
        _speedChanger.SpeedForFrame = _speedChanger.SpeedForFrame + newSpeed;

        _addGameSpeedForFrameCondition.text = _speedChanger.SpeedForFrame.ToString("0.0000");
    }

    public void ChangeSpeedForFrameFactor(float newFactor)
    {
        _speedChanger.SpeedChangeFactor = _speedChanger.SpeedChangeFactor + newFactor;

        _addGameSpeedForFrameFactorCondition.text = _speedChanger.SpeedChangeFactor.ToString("0.0");
    }

    public void ChangeDifficultCoefForGeneration(float newValue)
    {
        _postsController.AddDifficultCoefForGeneration = _postsController.AddDifficultCoefForGeneration + newValue;

        _difficultCoefForGenerationCondition.text = _postsController.AddDifficultCoefForGeneration.ToString("0.000");
    }

    public void ChangeCharacterMass(float newValue)
    {
        _characterRB.mass = _characterRB.mass + newValue;

        _characterMassCondition.text = _characterRB.mass.ToString("0.00");
    }

    public void ChangeCharacterAngularDrag(float newValue)
    {
        _characterRB.angularDrag = _characterRB.angularDrag + newValue;

        _characterAngularDragCondition.text = _characterRB.angularDrag.ToString("0.00");
    }

    public void ChangeCharacterGravity(float newValue)
    {
        _characterRB.gravityScale = _characterRB.gravityScale + newValue;

        _characterGravityCondition.text = _characterRB.gravityScale.ToString("0.00");
    }

    public void EnableDebugMode(bool condition)
    {
        condition = _utilits.LoopBoolValue(_debugGroupSwitcher.enabled, condition);

        if (condition == true)
        {
            _UIController.SetPreset("Debug");
            _debugInfoHandler.handle = true;
            _debugGroupSwitcher.enabled = true;
            _debugModeCondition.text = _On;
            _debugGroupSwitcher.SwitchHandleGroup(0);
        }
        else
        {
            _UIController.SetInvertPreset("Debug");
            _debugInfoHandler.handle = false;
            _debugGroupSwitcher.enabled = false;
            _debugModeCondition.text = _Off;
            _debugInfoDrawer.DestroyAll();
        }
    }
}
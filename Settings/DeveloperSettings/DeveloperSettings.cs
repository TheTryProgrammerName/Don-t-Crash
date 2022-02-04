using UnityEngine;
using TMPro;

public class DeveloperSettings : MonoBehaviour
{
    [SerializeField] private DebugUIController _debugUIController;
    [SerializeField] private ScoreUpdater _scoreUpdater;
    [SerializeField] private GraphicsMover _graphicsMover;
    [SerializeField] private Character _character;
    [SerializeField] private SpeedChanger _speedChanger;
    [SerializeField] private UIController _UIController;
    [SerializeField] private IsometricCorrector _isometricCorrector;

    [SerializeField] private Rigidbody2D _characterRB;

    [SerializeField] private TextMeshProUGUI _immortalityCondition;
    [SerializeField] private TextMeshProUGUI _postSpeedCondition;
    [SerializeField] private TextMeshProUGUI _characterSpeedCondition;
    [SerializeField] private TextMeshProUGUI _startGameSpeedCondition;
    [SerializeField] private TextMeshProUGUI _currentGameSpeedCondition;
    [SerializeField] private TextMeshProUGUI _maxGameSpeedCondition;
    [SerializeField] private TextMeshProUGUI _addGameSpeedForFrameCondition;
    [SerializeField] private TextMeshProUGUI _startGameDifficultCondition;
    [SerializeField] private TextMeshProUGUI _currentGameDifficultCondition;
    [SerializeField] private TextMeshProUGUI _addScoreCoefForRecordCondition;
    [SerializeField] private TextMeshProUGUI _characterMassCondition;
    [SerializeField] private TextMeshProUGUI _characterAngularDragCondition;
    [SerializeField] private TextMeshProUGUI _characterGravityCondition;
    [SerializeField] private TextMeshProUGUI _timeScaleCondition;
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
        _postSpeedCondition.text = _graphicsMover.Speed.ToString();
        _characterSpeedCondition.text = _character.Speed.ToString();
        _startGameDifficultCondition.text = _scoreUpdater.MinScoreCoef.ToString("0.00");
        _startGameSpeedCondition.text = _speedChanger.MinSpeed.ToString("0.00");
        _currentGameSpeedCondition.text = _speedChanger.CurrentSpeed.ToString("0.00");
        _maxGameSpeedCondition.text = _speedChanger.MaxSpeed.ToString("0.00");
        _addGameSpeedForFrameCondition.text = _speedChanger.SpeedForFrame.ToString("0.0000");
        _currentGameDifficultCondition.text = _scoreUpdater.ScoreCoef.ToString("0.00");
        _addScoreCoefForRecordCondition.text = _scoreUpdater.AddScoreCoefForRecord.ToString("0.000");
        _characterMassCondition.text = _characterRB.mass.ToString("0.00");
        _characterAngularDragCondition.text = _characterRB.angularDrag.ToString("0.00");
        _characterGravityCondition.text = _characterRB.gravityScale.ToString("0.00");
        _timeScaleCondition.text = Time.timeScale.ToString("0.0");
    }

    public void EnableImmortality(bool condition)
    {
        condition = _utilits.LoopBoolValue(_character.Immortality, condition);

        _character.Immortality = condition;

        if (condition == true)
        {
            _immortalityCondition.text = _On;
            _isometricCorrector.changeCharacterSortingOrder(100);
            _isometricCorrector.lockChangeSortingOrder = true;
        }
        else
        {
            _immortalityCondition.text = _Off;
            _isometricCorrector.lockChangeSortingOrder = false;
            _isometricCorrector.applyLastShoprtingOrder();
        }
    }

    public void ChangePostSpeed(int NewSpeed)
    {
        _graphicsMover.Speed = _graphicsMover.Speed + NewSpeed;
        _postSpeedCondition.text = _graphicsMover.Speed.ToString();
    }

    public void ChangeCharacterSpeed(int NewSpeed)
    {
        _character.Speed = _character.Speed + NewSpeed;
        _characterSpeedCondition.text = _character.Speed.ToString();
    }

    public void ChangeStartGameSpeed(float NewSpeed)
    {
        _speedChanger.MinSpeed = _speedChanger.MinSpeed + NewSpeed;

        _speedChanger.MinSpeed = _utilits.CheckFloatHighLimit(_speedChanger.MinSpeed, _speedChanger.MaxSpeed);

        _startGameSpeedCondition.text = _speedChanger.MinSpeed.ToString("0.00");
    }

    public void ChangeCurrentGameSpeed(float NewSpeed)
    {
        _speedChanger.CurrentSpeed = _speedChanger.CurrentSpeed + NewSpeed;

        _speedChanger.CurrentSpeed = _utilits.CheckFloatHighLimit(_speedChanger.CurrentSpeed, _speedChanger.MaxSpeed);
        _speedChanger.CurrentSpeed = _utilits.CheckFloatLowLimit(_speedChanger.CurrentSpeed, _speedChanger.MinSpeed);

        _currentGameSpeedCondition.text = _speedChanger.CurrentSpeed.ToString("0.00");
    }

    public void ChangeMaxGameSpeed(float NewSpeed)
    {
        _speedChanger.MaxSpeed = _speedChanger.MaxSpeed + NewSpeed;

        _speedChanger.MaxSpeed = _utilits.CheckFloatLowLimit(_speedChanger.MaxSpeed, _speedChanger.CurrentSpeed);

        _maxGameSpeedCondition.text = _speedChanger.MaxSpeed.ToString("0.00");
    }

    public void ChangeSpeedForFrame(float NewSpeed)
    {
        _speedChanger.SpeedForFrame = _speedChanger.SpeedForFrame + NewSpeed;

        _addGameSpeedForFrameCondition.text = _speedChanger.SpeedForFrame.ToString("0.0000");
    }

    public void ChangeStartGameDifficult(float NewSpeed)
    {
        _scoreUpdater.MinScoreCoef = _scoreUpdater.MinScoreCoef + NewSpeed;

        _startGameDifficultCondition.text = _scoreUpdater.MinScoreCoef.ToString("0.00");
    }

    public void ChangeCurrentGameDifficult(float NewSpeed)
    {
        _scoreUpdater.ScoreCoef = _scoreUpdater.ScoreCoef + NewSpeed;

        _scoreUpdater.ScoreCoef = _utilits.CheckFloatLowLimit(_scoreUpdater.ScoreCoef, _scoreUpdater.MinScoreCoef);

        _scoreUpdater.sendScore();

        _currentGameDifficultCondition.text = _scoreUpdater.ScoreCoef.ToString("0.00");
    }

    public void ChangeDifficultForRecord(float NewValue)
    {
        _scoreUpdater.AddScoreCoefForRecord = _scoreUpdater.AddScoreCoefForRecord + NewValue;

        _addScoreCoefForRecordCondition.text = _scoreUpdater.AddScoreCoefForRecord.ToString("0.000");
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

    public void ChangeTimeScale(float NewValue)
    {
        Time.timeScale = Time.timeScale + NewValue;

        _timeScaleCondition.text = Time.timeScale.ToString("0.0");
    }

    public void EnableDebugMode(bool condition)
    {
        condition = _utilits.LoopBoolValue(_debugUIController.enabled, condition);

        if (condition == true)
        {
            _UIController.SetPreset("Debug");
            _debugUIController.enabled = true;
            _debugModeCondition.text = _On;
        }
        else
        {
            _UIController.SetInvertPreset("Debug");
            _debugUIController.enabled = false;
            _debugModeCondition.text = _Off;
        }
    }
}
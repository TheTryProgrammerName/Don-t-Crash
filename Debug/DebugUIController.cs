using UnityEngine;
using TMPro;

public class DebugUIController : MonoBehaviour
{
    [SerializeField] private FPSCounter _FPSCounter;
    [SerializeField] private LogViewer _logViewer;
    [SerializeField] private UIController _UIController;

    [SerializeField] private TextMeshProUGUI modeName;
    [SerializeField] string[] modes;

    private int _modeNuimber;
    private int _lastModeNuimber;

    public void Initialize()
    {
        _lastModeNuimber = modes.Length - 1;
    }

    public void SwitchMode(int modeNumber)
    {
        _modeNuimber += modeNumber;

        if (_modeNuimber > _lastModeNuimber)
        {
            _modeNuimber = 0;
        }

        if (_modeNuimber < 0)
        {
            _modeNuimber = _lastModeNuimber;
        }

        modeName.text = modes[_modeNuimber];

        _UIController.SetPreset("Debug"+ modes[_modeNuimber]);
    }
}

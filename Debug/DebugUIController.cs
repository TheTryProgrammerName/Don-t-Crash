using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DebugUIController : MonoBehaviour
{
    [SerializeField] private DebugInfoHandler _debugInfoHandler;
    [SerializeField] private DebugInfoDrawer _debugInfoDrawer;
    [SerializeField] private TextMeshProUGUI groupName;

    private List<string> _debugInfoGroups;

    private int _drawingGroupNumber;
    private int _lastGroupNuimber;

    public void Initialize()
    {
        _debugInfoGroups = new List<string>();

        for (int i = 0; i < _debugInfoHandler.debugGroups.Count; i++)
        {
            _debugInfoGroups.Add(_debugInfoHandler.debugGroups[i].Name);
        }

        _lastGroupNuimber = _debugInfoGroups.Count - 1;

        SwitchHandleGroup(0);
    }

    public void SwitchHandleGroup(int number)
    {
        _drawingGroupNumber += number;

        if (_drawingGroupNumber > _lastGroupNuimber)
        {
            _drawingGroupNumber = 0;
        }

        if (_drawingGroupNumber < 0)
        {
            _drawingGroupNumber = _lastGroupNuimber;
        }

        _debugInfoHandler.switchHandleGroup(_debugInfoGroups[_drawingGroupNumber]);
        _debugInfoDrawer.onSwitchHandleGroup(_debugInfoHandler.debugGroups[_drawingGroupNumber].Info.Count);
        _debugInfoDrawer.DrawInfo(_debugInfoHandler.debugGroups[_drawingGroupNumber]);

        groupName.text = _debugInfoGroups[_drawingGroupNumber];
    }
}

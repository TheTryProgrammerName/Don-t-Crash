using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DebugGroupSwitcher : MonoBehaviour
{
    [SerializeField] private DebugInfoHandler _debugInfoHandler;
    [SerializeField] private DebugGroupsBuffer _debugGroupsBuffer;

    [SerializeField] private TextMeshProUGUI _curentGroupName;

    private List<string> _namesGroup;

    private int _handleGroupNumber;
    private int _groupsCount;
    
    public void Initialize()
    {
        _debugInfoHandler.Initialize();
        _debugGroupsBuffer.Initialize();
        _namesGroup = new List<string>();
    }

    public void AddGroupName(string name)
    {
        _namesGroup.Add(name);
        _groupsCount = _namesGroup.Count;
    }

    public void SwitchHandleGroup(int number)
    {
        _handleGroupNumber += number;

        if (_handleGroupNumber > _groupsCount - 1)
        {
            _handleGroupNumber = 0;
        }

        if (_handleGroupNumber < 0)
        {
            _handleGroupNumber = _groupsCount - 1;
        }

        string handleGroupName = _namesGroup[_handleGroupNumber];
        DebugGroup handleGruop = _debugGroupsBuffer.DebugGroups[handleGroupName];

        _debugInfoHandler.switchHandleGroup(handleGruop);
        _curentGroupName.text = _namesGroup[_handleGroupNumber];
    }
}
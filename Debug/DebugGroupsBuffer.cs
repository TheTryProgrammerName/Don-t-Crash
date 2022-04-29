using System.Collections.Generic;
using UnityEngine;

public class DebugGroupsBuffer : MonoBehaviour
{
    [SerializeField] private DebugGroupSwitcher _debugGroupSwitcher;

    public Dictionary<string, DebugGroup> DebugGroups { get; private set; }

    public void Initialize()
    {
        DebugGroups = new Dictionary<string, DebugGroup>();
    }

    public bool HasGroup(string name)
    {
        if (DebugGroups.ContainsKey(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RegisterGroup(string name)
    {
        DebugGroups.Add(name, new DebugGroup());
        _debugGroupSwitcher.AddGroupName(name);
    }
}
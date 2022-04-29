using UnityEngine;

public class DebugInfoHandler : MonoBehaviour
{
    [SerializeField] private DebugInfoDrawer _debugInfoDrawer;
    [SerializeField] private DebugGroupsBuffer _debugGroupsBuffer;

    private DebugGroup _handleGroup;

    public bool handle;

    public void Initialize()
    {
        _debugInfoDrawer.Initialize();
    }

    public void switchHandleGroup(DebugGroup group)
    {
        _handleGroup = group;
        _debugInfoDrawer.DrawInfo(_handleGroup.Info);
    }

    public void handleInfo(string groupName, string name, object value)
    {
        if (!_debugGroupsBuffer.HasGroup(groupName))
        {
            _debugGroupsBuffer.RegisterGroup(groupName);
        }

        _debugGroupsBuffer.DebugGroups[groupName].UpdateInfo(name, value);

        if (handle && _handleGroup.HasInfo(name))
        {
            _debugInfoDrawer.DrawInfo(_handleGroup.Info);
        }
    }
}
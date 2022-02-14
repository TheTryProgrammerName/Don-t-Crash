using UnityEngine;
using System.Collections.Generic;

public class DebugInfoHandler : MonoBehaviour
{
    [SerializeField] private DebugInfoDrawer _debugInfoDrawer;
    [SerializeField] private DebugUIController _debugUIController;

    public List<DebugGroup> debugGroups;

    public bool handle = false;
    private string handleGroupName;
    private DebugGroup handleGroup;

    public void Initialize()
    {
        debugGroups = new List<DebugGroup>();
    }

    public void switchHandleGroup(string handleGroup)
    {
        handleGroupName = handleGroup;
    }

    public void initializeInfo(string groupName, string infoName)
    {
        if (GetGroupByName(groupName) == null)
        {
            DebugGroup debugGroup = new DebugGroup();
            debugGroup.Name = groupName;

            debugGroups.Add(debugGroup);
        }

        DebugGroup initializedGroup = GetGroupByName(groupName);

        if (initializedGroup.GetInfoByName(infoName) == null)
        {
            Info info = new Info();
            info.Name = infoName;
            info.Value = "";

            initializedGroup.Info.Add(info);
        }
    }

    public void handleInfo(string groupName, string infoName, string infoValue)
    {
        if (handle)
        {
            if (handleGroup == null || handleGroup.Name != groupName)
            {
                handleGroup = GetGroupByName(groupName);
            }
            
            Info info = handleGroup.GetInfoByName(infoName);

            info.Value = infoValue;

            if (groupName == handleGroupName) //Если на обработку пришла та группа, за которой мы следим - отрисовываем её значения
            {
                _debugInfoDrawer.DrawInfo(handleGroup);
            }
        }
    }

    private DebugGroup GetGroupByName(string name)
    {
        int GroupsCount = debugGroups.Count;

        for (int i = 0; i < GroupsCount; i++)
        {
            if (debugGroups[i].Name == name)
            {
                return debugGroups[i];
            }
        }

        return null;
    }
}

public class DebugGroup
{
    public string Name;
    public List<Info> Info;

    public DebugGroup()
    {
        Info = new List<Info>();
    }

    public Info GetInfoByName(string name)
    {
        int InfoCount = Info.Count;

        for (int i = 0; i < InfoCount; i++)
        {
            if (Info[i].Name == name)
            {
                return Info[i];
            }
        }

        return null;
    }
}

public class Info 
{
    public string Name;
    public string Value;
}
using System.Collections.Generic;

public class DebugGroup
{
    public Dictionary<string, object> Info { private set; get; }

    public DebugGroup()
    {
        Info = new Dictionary<string, object>();
    }

    public void UpdateInfo(string name, object value)
    {
        Info[name] = value;
    }

    public object GetInfoByName(string name)
    {
        return Info[name];
    }

    public bool HasInfo(string name)
    {
        return Info.ContainsKey(name);
    }
}

using UnityEngine;

public class DebugInfoSender
{
    private DebugInfoHandler _debugInfoHandler;

    public DebugInfoSender()
    {
        _debugInfoHandler = MonoBehaviour.FindObjectOfType<DebugInfoHandler>();
    }

    public void SendInfo(string groupName, string infoName, object infoValue)
    {
        _debugInfoHandler.handleInfo(groupName, infoName, infoValue);
    }
}

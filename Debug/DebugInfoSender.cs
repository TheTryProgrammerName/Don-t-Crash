using UnityEngine;

public class DebugInfoSender : MonoBehaviour
{
    private DebugInfoHandler debugInfoHandler;

    public DebugInfoSender()
    {
        debugInfoHandler = FindObjectOfType<DebugInfoHandler>();
    }

    public void RegisterInfo(string groupName, string infoName)
    {
        debugInfoHandler.registerInfo(groupName, infoName);
    }

    public void SendInfo(string groupName, string infoName, object infoValue)
    {
        debugInfoHandler.handleInfo(groupName, infoName, infoValue);
    }
}

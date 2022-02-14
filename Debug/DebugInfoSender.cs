using UnityEngine;

public class DebugInfoSender : MonoBehaviour
{
    private DebugInfoHandler debugInfoHandler;

    public DebugInfoSender()
    {
        debugInfoHandler = FindObjectOfType<DebugInfoHandler>();
    }

    public void InitializeInfo(string groupName, string infoName)
    {
        debugInfoHandler.initializeInfo(groupName, infoName);
    }

    public void SendInfo(string groupName, string infoName, string infoValue)
    {
        debugInfoHandler.handleInfo(groupName, infoName, infoValue);
    }
}

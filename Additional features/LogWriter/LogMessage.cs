using UnityEngine;

public class LogMessage
{
    public LogType Type;
    public string Message;

    public LogMessage(LogType type, string message)
    {
        Type = type;
        Message = message;
    }
}

using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class LogWriter : MonoBehaviour
{
    [SerializeField] private UnityEvent _onLogMessageRecived;

    private string _workDirrectory;
    private FileWriter _fileWriter;

    private void Awake()
    {
        _workDirrectory = Application.persistentDataPath + "/logs";

        if (!Directory.Exists(_workDirrectory))
        {
            Directory.CreateDirectory(_workDirrectory);
        }

        _fileWriter = new FileWriter(_workDirrectory);
        _fileWriter.Clear();

        Application.logMessageReceived += OnLogMessageRecived;
    }

    private void OnLogMessageRecived(string condition, string stacktrace, LogType type)
    {
        if (type != LogType.Warning)
        {
            _fileWriter.Write(new LogMessage(type, condition));

            _onLogMessageRecived.Invoke();
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEditor.EditorUtility.RevealInFinder(_workDirrectory);
        }
#endif
    }
}

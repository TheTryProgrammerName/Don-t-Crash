using UnityEngine;
using TMPro;
using System.IO;
using System.Collections;

public class LogViewer : MonoBehaviour
{
    [SerializeField] private GameObject _logTextPrefab;
    [SerializeField] private Transform _scrollViewContent;
    [SerializeField] private string[] _logs; //Сами логи (string)

    private string _pathToLog;
    private string[] _clearString;
    private Queue _instantieteLogs = new Queue(); //Логи в UI (GameObject)

    private bool _isEnabled;

    public void initialize()
    {
        _pathToLog = Application.persistentDataPath + "/logs/log.log";
    }

    public void OnEnable()
    {
        _isEnabled = true;

        ReadLog();

        for (int i = 0; i < _logs.Length; i++)
        {
            CreateLogText(_logs[i]);
        }
    }

    public void OnUpdate()
    {
        if (_isEnabled)
        {
            ReadLog();

            int LastStringNumber = _logs.Length;
            string LastString = _logs[LastStringNumber];
            CreateLogText(LastString);
        }
    }

    public void OnDisable()
    {
        _isEnabled = false;

        int InstantieteLogsCount = _instantieteLogs.Count;

        for (int i = 0; i < InstantieteLogsCount; i++)
        {
            GameObject InstantieteLogTextObject = (GameObject)_instantieteLogs.Dequeue();
            DestroyLogText(InstantieteLogTextObject);
            ClearLog();
        }
    }

    private void ReadLog() //Читает весь лог 
    {
        _logs = File.ReadAllLines(_pathToLog);
    }

    private void ClearLog()
    {
        _logs = _clearString;
    }

    private void CreateLogText(string DrawingText) //Создаёт один лог с конкретным текстом
    {
        GameObject InstantiateLogObject = Instantiate(_logTextPrefab);
        Transform InstantiateLogTransform = InstantiateLogObject.transform;
        TextMeshProUGUI InstantiateLogText = InstantiateLogObject.GetComponent<TextMeshProUGUI>();

        _instantieteLogs.Enqueue(InstantiateLogObject);

        InstantiateLogText.text = DrawingText;

        InstantiateLogTransform.SetParent(_scrollViewContent); //Прифигачиваем объект к контенту
        InstantiateLogTransform.localScale = Vector3.one; //Выдаём ему адекватный размер      
        InstantiateLogTransform.localPosition = Vector3.zero; //И ставим в нулевые координаты
    }

    private void DestroyLogText(GameObject LogTextObject)
    {
        Destroy(LogTextObject);
    }
}

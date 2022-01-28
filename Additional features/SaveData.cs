using UnityEngine;

public class SaveData
{
    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public void SaveFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public int LoadInt(string key)
    {
        try
        {
            return PlayerPrefs.GetInt(key);
        }
        catch
        {
            CheckError(key);
        }

        return 0;
    }

    public float LoadFloat(string key)
    {
        try
        {
            return PlayerPrefs.GetFloat(key);
        }
        catch
        {
            CheckError(key);
        }

        return 0;
    }

    public string LoadString(string key)
    {
        try
        {
            return PlayerPrefs.GetString(key);
        }
        catch
        {
            CheckError(key);
        }

        return "";
    }

    public void Clear(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    private void CheckError(string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            Debug.LogError("Сохраниние с таким именем отсутствует");
        }
        else if (key == null)
        {
            Debug.LogError("Не присвоено значение key");
        }
        else
        {
            Debug.LogError("Неизвестная ошибка");
        }
    }
}
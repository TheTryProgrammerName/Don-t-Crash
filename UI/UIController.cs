using UnityEngine;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [SerializeField] private Preset[] _presets;

    private Dictionary<Preset, bool> _savedPresets;

    public void Initialize()
    {
        _savedPresets = new Dictionary<Preset, bool>();
    }

    public void SetPreset(string presetName)
    {
        Preset preset = getPresetByName(presetName);

        preset.Set(true);
    }

    public void SetInvertPreset(string presetName)
    {
        Preset preset = getPresetByName(presetName);

        preset.Set(false);
    }

    public void SavePreset(string presetName) //—охран€ем пресет, к которому будем возвращатьс€
    {
        Preset savedPreset = getPresetByName(presetName);

        _savedPresets.Add(savedPreset, true);
    }

    public void SaveInvertPreset(string presetName) //—охран€ем инвертированный пресет, к которому будем возвращатьс€
    {
        Preset savedPreset = getPresetByName(presetName);

        _savedPresets.Add(savedPreset, false);
    }

    private Preset getPresetByName(string presetName)
    {
        foreach (Preset preset in _presets)
        {
            if (preset.Name == presetName)
            {
                return preset;
            }
        }

        Debug.LogErrorFormat("ѕресет не найден: {0}", presetName);

        return new Preset();
    }

    public void SetSavedPresets() //”станавливаем пресеты, к которым хотели вернутьс€
    {
        foreach (KeyValuePair<Preset, bool> keyValuePair in _savedPresets)
        {
            Preset savedPreset = keyValuePair.Key;
            bool presetCondition = keyValuePair.Value;

            savedPreset.Set(presetCondition);
        }

        _savedPresets.Clear();
    }
}

[System.Serializable]
public struct Preset
{
    public string Name;

    public GameObject[] ActivateObjects;
    public GameObject[] DeactivateObjects;

    public void Set(bool enable)
    {
        foreach (GameObject enabledObject in ActivateObjects)
        {
            enabledObject.SetActive(enable);
        }

        foreach (GameObject disabledObject in DeactivateObjects)
        {
            disabledObject.SetActive(!enable);
        }
    }
}
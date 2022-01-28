using UnityEngine;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [SerializeField] private Preset[] _presets;

    private Queue<string> _backingPresets = new Queue<string>();
    private Queue<string> _invertBackingPresets = new Queue<string>();

    private GameObject[] _activateObjects;
    private GameObject[] _deactivateObjects;

    public void SetPreset(string PresetName)
    {
        GetPresetObjects(PresetName);

        for (int i = 0; i < _activateObjects.Length; i++)
        {
            _activateObjects[i].SetActive(true);
        }

        for (int i = 0; i < _deactivateObjects.Length; i++)
        {
            _deactivateObjects[i].SetActive(false);
        }
    }

    public void SetInvertPreset(string PresetName) //Выключаемые объекты вклчюаем, а включаемые выключаем
    {
        GetPresetObjects(PresetName);

        for (int i = 0; i < _activateObjects.Length; i++)
        {
            _activateObjects[i].SetActive(false);
        }

        for (int i = 0; i < _deactivateObjects.Length; i++)
        {
            _deactivateObjects[i].SetActive(true);
        }
    }

    public void SaveBackingPreset(string PresetName) //Сохраняем пресет, к которому будем возвращаться
    {
        _backingPresets.Enqueue(PresetName);
    }

    public void SaveInvertBackingPreset(string PresetName) //Сохраняем инвертированный пресет, к которому будем возвращаться
    {
        _invertBackingPresets.Enqueue(PresetName);
    }

    public void SetBackingPreset() //Устанавливаем пресеты, к которым хотели вернуться
    {
        for (int i = 0; i < _backingPresets.Count;)
        {
            SetPreset(_backingPresets.Dequeue());
        }
        for (int i = 0; i < _invertBackingPresets.Count;)
        {
            SetInvertPreset(_invertBackingPresets.Dequeue());
        }
    }

    private void GetPresetObjects(string PresetName)
    {
        for (int PresetNumber = 0; PresetNumber < _presets.Length; PresetNumber++)
        {
            if (_presets[PresetNumber].PresetName == PresetName)
            {
                Preset Preset = _presets[PresetNumber];
                _activateObjects = Preset.ActivateObjects;
                _deactivateObjects = Preset.DeactivateObjects;

                return;
            }
        }
    }
}

[System.Serializable]
public class Preset
{
    public string PresetName;

    public GameObject[] ActivateObjects;
    public GameObject[] DeactivateObjects;
}
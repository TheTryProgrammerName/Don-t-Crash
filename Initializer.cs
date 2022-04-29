using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private DebugGroupSwitcher _debugGroupSwitcher;
    [SerializeField] private GameConditions _gameConditions;
    [SerializeField] private DeveloperSettings _developerSettings;
    [SerializeField] private UIController _uiController;

    private ObjectsPool[] _objectsPools;
    private UIFadeout[] _UIFadeouts;

    private void Awake()
    {
        _UIFadeouts = FindObjectsOfType<UIFadeout>();
        _objectsPools = FindObjectsOfType<ObjectsPool>();

        foreach (ObjectsPool objectsPool in _objectsPools)
        {
            objectsPool.Initialize();
        }

        _debugGroupSwitcher.Initialize();
        _gameConditions.Initialize();
        _developerSettings.Initizlize();
        _uiController.Initialize();

        /*int UIFadeoutsLenght = _UIFadeouts.Length;

        for (int i = 0; i < UIFadeoutsLenght; i++)
        {
            _UIFadeouts[0].Initialize();
        }*/

        Destroy(this);
    }
}

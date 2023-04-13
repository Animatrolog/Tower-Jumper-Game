using UnityEngine;
using UnityEngine.UI;


public class SettingsToggles : MonoBehaviour
{
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private UiSoundManager _uiSoundManager;

    public static SettingsToggles Instance { get; private set; }

    private GameDataManager _gameDataManager;

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        LoadSettings();
    }

    private void LoadSettings()
    {
        _soundToggle.isOn = _gameDataManager.IsSoundEnabled;
        _uiSoundManager.EnableSound(_gameDataManager.IsSoundEnabled);
    }

}

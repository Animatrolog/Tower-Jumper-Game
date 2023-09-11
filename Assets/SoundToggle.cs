using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] private GameDataManager _gameDataManager;
    [SerializeField] private UiSoundManager _uISoundManager;

    public void ToggleSound(bool state)
    {
        _uISoundManager.EnableSound(state);
        _gameDataManager.GameSaveData.IsSoundEnabled = state;
        _gameDataManager.SaveGameData();
    }
}

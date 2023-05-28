using UnityEngine;
using UnityEngine.UI;

public class SensitivityManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private MouseInput _input;

    private GameDataManager _gameDataManager;

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        LoadSensitivity();
    }

    private void LoadSensitivity()
    {
        float newSensitivity = _gameDataManager.GameSaveData.Sensitivity;
        _slider.value = newSensitivity;
        _input.Sensitivity = newSensitivity;
    }

    public void UpdateSensitivity()
    {
        _input.Sensitivity = _slider.value;
        _gameDataManager.GameSaveData.Sensitivity = _slider.value;
    }
}

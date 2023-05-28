using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSkinManager : MonoBehaviour
{
    [SerializeField] private List<Skin> _skins;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private Transform _skinContainer;

    private GameObject _currentSkin;
    private int _currentSkinID;
    private GameDataManager _gameDataManager;

    public static PlayerSkinManager Instance;
    public UnityEvent OnSkinChanged;
    public List<Skin> Skins => _skins;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        LoadSkinID();
    }

    private void LoadSkinID()
    {
        ChangeSkin(_gameDataManager.GameSaveData.SkinID);
    }

    public void ChangeSkin(int skinID)
    {
        if (_currentSkin != null)
        { 
            if (skinID == _currentSkinID) return;
            Destroy(_currentSkin);
            Instantiate(_particles, _skinContainer);
            OnSkinChanged?.Invoke();
        }
        _currentSkin = Instantiate(_skins[skinID].Model, _skinContainer);
        _currentSkinID = skinID;
        _gameDataManager.GameSaveData.SkinID = skinID;
    }
}

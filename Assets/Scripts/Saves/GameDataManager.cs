using UnityEngine;
using UnityEngine.Events;

public class GameDataManager : MonoBehaviour
{
    [SerializeField] private Color _playerColor;
    [SerializeField] private int _level;
    [SerializeField] private bool _isSoundEnabled;
    [SerializeField] private bool _isAdsEnabled;
    [SerializeField] private int _coins;
    [SerializeField] private int _maxCombo;
    [SerializeField] private float _sensitivity;
    [SerializeField] private int _skinID;
    [SerializeField] private bool _clearDataOnAwake;

    public static GameDataManager Instance;
    public int Gems;
    public UnityAction<int> OnCoinCountChange;

    public Color PlayerColor { get => _playerColor; set { _playerColor = value; SaveGameData(); }}
    public int Level { get => _level; set { _level = value; SaveGameData(); }}
    public int MaxCombo { get => _maxCombo; set { _maxCombo = value; SaveGameData(); }}
    public int SkinID { get => _skinID; set { _skinID = value; SaveGameData(); } }
    public bool IsSoundEnabled { get => _isSoundEnabled; set { _isSoundEnabled = value; SaveGameData(); }}
    public bool IsAdsEnabled { get => _isAdsEnabled; set { _isAdsEnabled = value; SaveGameData(); }}
    public int Coins { get => _coins; set { _coins = value; SaveGameData(); OnCoinCountChange?.Invoke(value); } }
    public float Sensitivity { get => _sensitivity; set { _sensitivity = value; SaveGameData(); } }

    private void Awake()
    {
        if (_clearDataOnAwake) SaveSystem.Cleardata();
        LoadGameData();
        Instance = this;
    }

    private void LoadGameData()
    {
        GameSaveData gameSaveData =  SaveSystem.LoadData();
        if (gameSaveData == null) return;

        float[] colorArray = gameSaveData.PlayerColor;
        PlayerColor = new(colorArray[0], colorArray[1], colorArray[2], 1f);

        Level = gameSaveData.Level;
        Coins = gameSaveData.Coins;
        Gems = gameSaveData.Gems;
        MaxCombo = gameSaveData.MaxCombo;
        SkinID= gameSaveData.SkinID;

        Sensitivity = gameSaveData.Sensitivity;
        IsSoundEnabled = gameSaveData.IsSoundEnabled;
        IsAdsEnabled = gameSaveData.IsAdsEnabled;
    }

    public void SaveGameData()
    {
        SaveSystem.SaveData(this);
    }

}

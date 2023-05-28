using UnityEngine;
using UnityEngine.Events;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    public UnityAction<int> OnScoreChange;
    public GameSaveData GameSaveData { get; private set; }

    private void Awake()
    {
        LoadGameData();
        Instance = this;
    }

    private void LoadGameData()
    {
        GameSaveData = SaveSystem.LoadData();
        GameSaveData.OnDataChanged += SaveGameData;
    }

    public void SaveGameData()
    {
        SaveSystem.SaveData(GameSaveData);
        OnScoreChange?.Invoke(GameSaveData.GameScore);
    }

}

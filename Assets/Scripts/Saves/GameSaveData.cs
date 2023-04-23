using System.Collections.Generic;

[System.Serializable]
public class GameSaveData
{
    public float[] PlayerColor = new float[3];
    public int Level;
    public int Coins;
    public int Gems;
    public int SkinID;
    public int TraitID;
    public int MaxCombo;
    public float Sensitivity;
    public bool IsSoundEnabled;
    public bool IsAdsEnabled;
    public List<int> UnlockedSkins;

    public GameSaveData(GameDataManager gameDataManager)
    {
        PlayerColor[0] = gameDataManager.PlayerColor.r;
        PlayerColor[1] = gameDataManager.PlayerColor.g;
        PlayerColor[2] = gameDataManager.PlayerColor.b;

        Level = gameDataManager.Level;
        Coins = gameDataManager.Coins;
        Gems = gameDataManager.Gems;
        MaxCombo= gameDataManager.MaxCombo;
        SkinID= gameDataManager.SkinID;

        Sensitivity = gameDataManager.Sensitivity;
        IsSoundEnabled = gameDataManager.IsSoundEnabled;
        IsAdsEnabled = gameDataManager.IsAdsEnabled;
    }
}

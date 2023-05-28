using System.Collections.Generic;
using UnityEngine;

public class SkinUnlocker : MonoBehaviour
{
    private GameDataManager _gameDataManager;
    private PlayerSkinManager _playerSkinManager;

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        _playerSkinManager = PlayerSkinManager.Instance;
        LoadSkinData();
    }

    private void LoadSkinData()
    {
        if(_gameDataManager.GameSaveData.NextSkinProgress >= 1f)
        {
            _gameDataManager.GameSaveData.NextSkinIndex = 0;
            _gameDataManager.GameSaveData.NextSkinProgress = 0f;
        }

        var skins = _playerSkinManager.Skins;
        var unlockedSkins = _gameDataManager.GameSaveData.UnlockedSkins;

        if (skins.Count == unlockedSkins.Count)
            return;

        List<Skin> lockedSkins= new List<Skin>();

        foreach (var skin in skins)
        {
            if (!unlockedSkins.Contains(skins.IndexOf(skin)))
                lockedSkins.Add(skin);
        }

        if(_gameDataManager.GameSaveData.NextSkinIndex == 0)
            _gameDataManager.GameSaveData.NextSkinIndex = skins.IndexOf(lockedSkins[Random.Range(0, lockedSkins.Count)]);
    }

    public void UnlockNewSkin()
    {
        if(!_gameDataManager.GameSaveData.UnlockedSkins.Contains(_gameDataManager.GameSaveData.NextSkinIndex))
            _gameDataManager.GameSaveData.UnlockedSkins.Add(_gameDataManager.GameSaveData.NextSkinIndex);
        _gameDataManager.GameSaveData.NextSkinIndex = 0;
    }
}

using UnityEngine;
using System.IO;
using Agava.YandexGames;

public static class SaveSystem
{
    private static readonly string _path = Application.persistentDataPath + "/GameData.json";

    private static GameSaveData _gameSaveData;

    public static void SaveData(GameSaveData gameSaveData)
    {
        string json = JsonUtility.ToJson(gameSaveData);
        File.WriteAllText(_path, json);
#if !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
            PlayerAccount.SetCloudSaveData(json);
#endif
    }

    public static GameSaveData LoadData()
    {
#if UNITY_EDITOR
        LoadLocalSaveData();
#endif
        return _gameSaveData;
    }

    public static void LoadLocalSaveData()
    {
        if (File.Exists(_path))
        {
            string json = File.ReadAllText(_path);
            LoadDataFromJson(json);
            
            if (_gameSaveData == null)
            {
                Debug.LogWarning("Save fale is corrupted !");
                Cleardata();
                _gameSaveData = new GameSaveData();
            }
            Debug.Log("Local savedata loaded !");
        }
        else
        {
            Debug.Log("Savefile not found !");
            _gameSaveData = new GameSaveData();
            Debug.Log("New Savefile created !");
        }
    }

    public static void TryToLoadCloudSaveData()
    {
        if (PlayerAccount.IsAuthorized)
        {
            Debug.Log("Trying to load savedata from cloud.");
            
            PlayerAccount.GetCloudSaveData((data) => 
            {
                if (string.IsNullOrEmpty(data) || data == "{}")
                {
                    Debug.LogWarning("No saves in cloud !");
                    LoadLocalSaveData();
                    return;
                }
                Debug.Log("Savedata loaded from cloud.");
                LoadDataFromJson(data);
            },
            (error) =>
            {
                Debug.LogWarning(error);
                Debug.LogWarning("Error cant load data from cloud !");
                LoadLocalSaveData();
            });
        }
        else
            LoadLocalSaveData();
        //    PlayerAccount.Authorize(() =>
        //    {
        //        PlayerAccount.GetCloudSaveData(
        //            (data) => LoadDataFromJson(data),
        //            (error) =>
        //            {
        //                LoadLocalSaveData();
        //                Debug.LogWarning(error);
        //            }
        //        ); 
        //    },
        //    (error) => 
        //    { 
        //        LoadLocalSaveData(); 
        //        Debug.LogWarning(error); 
        //    });
    }

    private static void LoadDataFromJson(string json) 
    {
        _gameSaveData = JsonUtility.FromJson<GameSaveData>(json);
    }

    public static void Cleardata()
    {
        File.Delete(_path);
    }
}

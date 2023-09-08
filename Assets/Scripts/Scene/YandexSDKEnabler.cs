using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YandexSDKEnabler : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(EnableSDK());
    }

    private IEnumerator EnableSDK()
    {
#if UNITY_EDITOR
        SaveSystem.LoadLocalSaveData();
#else
        yield return YandexGamesSdk.Initialize();
        yield return SaveSystem.TryToLoadCloudSaveData();
#endif
        yield return SceneManager.LoadSceneAsync("Level");
    }
}

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine.Events;

public class YaSDK : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void Authenticate();
    [DllImport("__Internal")] private static extern void SetPlayerData(string data);
    [DllImport("__Internal")] private static extern void GetPlayerData();
    [DllImport("__Internal")] private static extern void ShowFullscreenAd();
    [DllImport("__Internal")] private static extern void OpenRateUs();
    [DllImport("__Internal")] private static extern int ShowRewardedAd(string placement);
    [DllImport("__Internal")] private static extern string GetPlayerLang();

    private int _rewardedAdPlacementAsInt = 0;
    private string _rewardedAdPlacement = string.Empty;
#if UNITY_EDITOR
    private GameObject _rewardedAdPrefab;
    private GameObject _interstitialAdPrefab;
#endif
    [SerializeField] private int _InterstitialInterval = 181;

    public event UnityAction OnPlayerAuthenticated;
    public event UnityAction<string> OnGetPlayerData;
    public static event UnityAction OnInterstitialShown;
    public event UnityAction<string> OnInterstitialFailed;
    public event UnityAction<int> OnRewardedAdOpened;
    public event UnityAction<string> OnRewardedAdReward;
    public event UnityAction<int> OnRewardedAdClosed;
    public event UnityAction<int> OnRewardedAdError;
        
    public bool IsInterstitialReady { get; private set; }
    public Platform CurrentPlatform { get; private set; }
    public bool CanReview { get; private set; }

    public static YaSDK Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        StartCoroutine(CountTillNextInterstitial());
    }

    public string GetLanguage()
    {
        return GetPlayerLang();
    }

    public void AuthenticateUser()
    {
        Authenticate();
    }

    public void SetCanReview(string str)
    {
        CanReview = (str == "yes")? true : false;
    }

    public void SetPlayerAuthenticated()
    {
        OnPlayerAuthenticated?.Invoke();
    }

    public void SetSave<T>(T saveStateClass)
    {
        string dataStr = JsonUtility.ToJson(saveStateClass);
        SetPlayerData(dataStr);
    }

    public void GetSave()
    {
        GetPlayerData();
    }

    public void PlayerDataSet(string dataStr)
    {
        if (!dataStr.Contains("none"))
        {
            OnGetPlayerData?.Invoke(dataStr);
        }
        else
        {
            OnGetPlayerData?.Invoke(string.Empty);
        }
    }

    public void SetPlayerPlatform(string p)
    {
        switch (p)
        {
            case "phone":
                CurrentPlatform = Platform.phone;
                break;
            case "desktop":
                CurrentPlatform = Platform.desktop;
                break;
        }
    }

    public void ShowInterstitial()
    {
        if (!IsInterstitialReady) return;

        IsInterstitialReady = false;

#if UNITY_EDITOR
        _interstitialAdPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/YandexSDK/Prefab/InterstitialAd.prefab", typeof(GameObject));
        Instantiate(_interstitialAdPrefab);
#else
        ShowFullscreenAd();
#endif
    }

    public void ShowRewarded(string placement)
    {
#if UNITY_EDITOR
        _rewardedAdPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/YandexSDK/Prefab/RewardedAd.prefab", typeof(GameObject));
        RewardedAdEditor reawrded = Instantiate(_rewardedAdPrefab).GetComponent<RewardedAdEditor>();

        reawrded.placement = placement;
#else
        _rewardedAdPlacementAsInt = (ShowRewardedAd(placement));
#endif
        _rewardedAdPlacement = (placement);
    }

    public void SetInterstitialShown()
    {
        OnInterstitialShown?.Invoke();
        StartCoroutine(CountTillNextInterstitial());
    }

    public void SetInterstitialError(string error)
    {
        OnInterstitialFailed?.Invoke(error);
    }

    public void SetRewardedOpen(int placement)
    {
        OnRewardedAdOpened?.Invoke(placement);
    }

#if UNITY_EDITOR
    public void OnRewarded(string placement)
    {
        if (placement == _rewardedAdPlacement)
        {
            OnRewardedAdReward?.Invoke(_rewardedAdPlacement);
        }
    }
#endif
    public void OnRewarded(int placement)
    {
        if (placement == _rewardedAdPlacementAsInt)
        {
            OnRewardedAdReward?.Invoke(_rewardedAdPlacement);
        }
    }

    public void OnRewardedClose(int placement)
    {
        OnRewardedAdClosed?.Invoke(placement);
    }

    public void OnRewardedError(int placement)
    {
        OnRewardedAdError?.Invoke(placement);
    }

    public void OpenRateUsWindow()
    {
        OpenRateUs();
        CanReview = false;
    }

    private IEnumerator CountTillNextInterstitial()
    {
        yield return new WaitForSecondsRealtime(_InterstitialInterval);
        IsInterstitialReady = true;
    }

}

public enum Platform
{
    phone,
    desktop
}

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
    private Coroutine _interstitialTimer = null;
#if UNITY_EDITOR
    private GameObject _rewardedAdPrefab;
    private GameObject _interstitialAdPrefab;
#endif
    [SerializeField] private int _InterstitialInterval = 181;

    public event UnityAction OnPlayerAuthenticated;
    public event UnityAction<string> OnGetPlayerData;

    public static event UnityAction OnInterstitialShown;
    public static event UnityAction OnInterstitialFailed
        ;
    public event UnityAction<int> OnRewardedAdOpened;
    public event UnityAction<string> OnRewardedAdReward;
    public event UnityAction OnRewardedAdClosed;
    public event UnityAction OnRewardedAdError;
        
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
        StartTimer();
    }

    private void StartTimer()
    {
        _interstitialTimer ??= StartCoroutine(CountTillNextInterstitial());
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
        StartTimer();
    }

    public void SetInterstitialError(string error)
    {
        OnInterstitialFailed?.Invoke();
    }

    public void SetRewardedOpen(int placement)
    {
        OnRewardedAdOpened?.Invoke(placement);
    }

#if UNITY_EDITOR
    public void SetRewarded(string placement)
    {
        if (placement == _rewardedAdPlacement)
        {
            OnRewardedAdReward?.Invoke(_rewardedAdPlacement);
        }
    }
#endif
    public void SetRewarded(int placement)
    {
        if (placement == _rewardedAdPlacementAsInt)
        {
            OnRewardedAdReward?.Invoke(_rewardedAdPlacement);
        }
    }

    public void SetRewardedClose(int placement)
    {
        OnRewardedAdClosed?.Invoke();
    }

    public void SetRewardedError(int placement)
    {
        OnRewardedAdError?.Invoke();
    }

    public void OpenRateUsWindow()
    {
        OpenRateUs();
        CanReview = false;
    }

    private IEnumerator CountTillNextInterstitial()
    {
        for (int i = _InterstitialInterval; i > 0; i--)
        {
            yield return new WaitForSecondsRealtime(1);
        }
        IsInterstitialReady = true;
    }

}

public enum Platform
{
    phone,
    desktop
}

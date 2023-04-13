using UnityEngine;

public class InterstitialAdHandler : MonoBehaviour
{
    [SerializeField] private AdPanel _adPanel;

    private void OnEnable()
    {
        YaSDK.OnInterstitialShown += AdClose;
        YaSDK.OnInterstitialFailed += AdClose;
    }

    private void OnDisable()
    {
        YaSDK.OnInterstitialShown -= AdClose;
        YaSDK.OnInterstitialFailed -= AdClose;
    }

    public static InterstitialAdHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool ShowAd()
    {
        if (!YaSDK.Instance.IsInterstitialReady) return false;
        YaSDK.Instance.ShowInterstitial();
        _adPanel.ShowPanel(true);
        return true;
    }

    private void AdClose()
    {
        _adPanel.ShowPanel(false);
    }
}

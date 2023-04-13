using UnityEngine;

public class InterstitialAdHandler : MonoBehaviour
{
    [SerializeField] private AdPanel _adPanel;

    private void OnEnable() => YaSDK.OnInterstitialShown += AdClose;

    private void OnDisable() => YaSDK.OnInterstitialShown -= AdClose;

    public static InterstitialAdHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowAd()
    {
        if (!YaSDK.Instance.IsInterstitialReady) return;
        YaSDK.Instance.ShowInterstitial();
        _adPanel.ShowPanel(true);
    }

    private void AdClose()
    {
        _adPanel.ShowPanel(false);
    }
}

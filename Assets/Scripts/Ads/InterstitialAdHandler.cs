using Agava.YandexGames;
using System;
using UnityEngine;

public class InterstitialAdHandler : MonoBehaviour
{
    [SerializeField] private AdPanel _adPanel;

    public static InterstitialAdHandler Instance;
    public Action OnInterstitialShown;

    private void Awake()
    {
        Instance = this;
    }

    public bool ShowAd()
    {
        if(InterstitialAdTimer.Instance.TryToStartTimer())
        {
#if UNITY_EDITOR
            Debug.Log("Here is your Interstitial ad massage !");
            AdClose();
#else
            InterstitialAd.Show(onCloseCallback: (bool state) => AdClose(), onErrorCallback: (string err) => AdClose());
            _adPanel.ShowPanel(true);
            return true;
#endif
        }
        return false;
    }

    private void AdClose()
    {
        _adPanel.ShowPanel(false);
        OnInterstitialShown?.Invoke();
    }
}

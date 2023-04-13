using UnityEngine;
using UnityEngine.Events;

public class RewardedAdHandler : MonoBehaviour
{
    [SerializeField] private string _placementName;
    [SerializeField] private UnityEvent _onRewardEarned;
    [SerializeField] private AdPanel _adPanel;

    private void OnEnable()
    {
        YaSDK.Instance.OnRewardedAdReward += RewardedVideoAdRewardedEvent;
        YaSDK.Instance.OnRewardedAdClosed += HidePanel;
        YaSDK.Instance.OnRewardedAdError += HidePanel;
    }

    private void OnDisable()
    {
        YaSDK.Instance.OnRewardedAdReward -= RewardedVideoAdRewardedEvent;
        YaSDK.Instance.OnRewardedAdClosed -= HidePanel;
        YaSDK.Instance.OnRewardedAdError -= HidePanel;
    }

    public void ShowRewardedAd()
    {
        ShowPanel();
        YaSDK.Instance.ShowRewarded(_placementName);
    }

    private void RewardedVideoAdRewardedEvent(string placementName)
    {
        if (placementName == _placementName)
        {
            _onRewardEarned?.Invoke();
        }
    }

    private void ShowPanel() 
    {
        _adPanel.ShowPanel(true);
    }

    private void HidePanel()
    {
        _adPanel.ShowPanel(false);
    }
}

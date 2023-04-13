using UnityEngine;
using UnityEngine.Events;

public class RewardedAdHandler : MonoBehaviour
{
    [SerializeField] private string _placementName;
    [SerializeField] private UnityEvent _onRewardEarned;
    [SerializeField] private AdPanel _adPanel;

    private GameDataManager _gameDataManager;

    private void OnEnable()
    {
        YaSDK.Instance.OnRewardedAdReward += RewardedVideoAdRewardedEvent;
    }

    private void OnDisable()
    {
        YaSDK.Instance.OnRewardedAdReward -= RewardedVideoAdRewardedEvent;
    }

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
    }

    public void ShowRewardedAd()
    {
        if (!_gameDataManager.IsAdsEnabled)
        {
            _onRewardEarned?.Invoke();
            return;
        }

        YaSDK.Instance.ShowRewarded(_placementName);
        _adPanel.ShowPanel(true);
    }

    private void RewardedVideoAdRewardedEvent(string placementName)
    {
        if (placementName == _placementName)
        {
            _adPanel.ShowPanel(false);
            _onRewardEarned?.Invoke();
        }
    }
}

using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class RewardedAdHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _onRewardEarned;
    [SerializeField] private AdPanel _adPanel;

    private bool _isRewardEarned;

    public void ShowRewardedAd()
    {
#if UNITY_EDITOR
        Debug.Log("Here is your Rewarded ad massage !");
        _onRewardEarned?.Invoke();
#else
        ShowPanel();
        VideoAd.Show(onRewardedCallback: () => _isRewardEarned= true, onCloseCallback: () => HidePanel(), onErrorCallback: (string err) => HidePanel()) ;
#endif
    }

    private void ShowPanel() 
    {
        _isRewardEarned = false;
        _adPanel.ShowPanel(true);
    }

    private void HidePanel()
    {
        _adPanel.ShowPanel(false);
        if(_isRewardEarned)
            _onRewardEarned?.Invoke();
    }
}

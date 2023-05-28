using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class RewardedAdHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _onRewardEarned;
    [SerializeField] private AdPanel _adPanel;

    public void ShowRewardedAd()
    {
#if UNITY_EDITOR
        Debug.Log("Here is your Rewarded ad massage !");
        _onRewardEarned?.Invoke();
#else
        ShowPanel();
        VideoAd.Show(onRewardedCallback: () => _onRewardEarned?.Invoke(), onCloseCallback: () => HidePanel(), onErrorCallback: (string err) => HidePanel()) ;
#endif
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

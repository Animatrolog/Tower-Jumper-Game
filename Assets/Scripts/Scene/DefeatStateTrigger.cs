using UnityEngine;
using UnityEngine.Events;

public class DefeatStateTrigger : MonoBehaviour
{
    public UnityEvent OnDefeat;

    public void TriggerDefeatState()
    {
        OnDefeat?.Invoke();
        InterstitialAdHandler.Instance.ShowAd();
        GameStateManager.Instance.SetState(GameState.Defeat);
    }
}

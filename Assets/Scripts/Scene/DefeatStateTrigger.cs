using UnityEngine;
using UnityEngine.Events;

public class DefeatStateTrigger : MonoBehaviour
{
    [SerializeField] private PlayerResurector _resurector;
    public UnityEvent OnDefeat;

    public void TriggerDefeatState()
    {
        OnDefeat?.Invoke();
        _resurector.PrepareResurection();
        GameStateManager.Instance.SetState(GameState.Defeat);
    }
}

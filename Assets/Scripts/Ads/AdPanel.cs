using UnityEngine;

public class AdPanel : MonoBehaviour
{
    [SerializeField] private GameObject _adPanel;

    public void ShowPanel(bool state)
    {
        _adPanel.SetActive(state);
        if (GameStateManager.CurrentGameState == GameState.Game)
            Time.timeScale = state ? 0f : 1f;
    }
}

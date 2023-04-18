using UnityEngine;

public class Pause : MonoBehaviour
{
    private GameStateManager _gameStateManager;

    void Start()
    {
        _gameStateManager = GameStateManager.Instance;
    }

    public void PauseGame()
    {
        _gameStateManager.SetState(GameState.Pause);
        TimeScaler.SetTimeScale(0f);
    }

    public void ResumeGame()
    {
        _gameStateManager.SetState(GameState.Game);
        TimeScaler.SetTimeScale(1f);
    }

    void OnApplicationFocus(bool hasFocus)
    {
        AudioListener.pause = !hasFocus;
        if (GameStateManager.CurrentGameState == GameState.Game)
            Time.timeScale = hasFocus? 1f : 0f;
    }
}

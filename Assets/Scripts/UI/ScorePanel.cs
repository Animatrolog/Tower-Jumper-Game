
using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private ScoreManager _scoreManager;
   
    private GameDataManager _gameDataManager;

    private void OnEnable()
    {
        _gameDataManager = GameDataManager.Instance;
    }

    private void Start()
    { 
        _gameDataManager.GameSaveData.GameScore += _scoreManager.Score;
        _counterText.text = _scoreManager.Score.ToString();
#if !UNITY_EDITOR
        if(PlayerAccount.IsAuthorized)
            Leaderboard.SetScore("LeaderBoard", _gameDataManager.GameSaveData.GameScore);
#endif
    }
}

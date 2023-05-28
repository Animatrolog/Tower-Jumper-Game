using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Agava.YandexGames;

public class PlayerScorePanel : MonoBehaviour
{
    [SerializeField] private LeaderBoardUIElement _uiElement;
    [SerializeField] private MultiLangSO _playerNameText;

    private GameDataManager _gameDataManager;

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        LoadPlayerEntry();
    }

    private void LoadPlayerEntry()
    {
#if !UNITY_EDITOR
        if(PlayerAccount.IsAuthorized)
        {
            Leaderboard.GetPlayerEntry("LeaderBoard", (result) =>
            {
                if (result == null)
                    Debug.Log("Player is not present in the leaderboard.");
                else
                    _uiElement.Initialize(result.player.publicName, result.score, result.rank, result.player.profilePicture);
            });
        }
        else
#endif
            _uiElement.Initialize(_playerNameText.GetText(LanguageManager.Instance.Language), _gameDataManager.GameSaveData.GameScore, 0, "");
    }
}

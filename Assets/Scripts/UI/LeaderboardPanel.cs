using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private LeaderBoardUIManager _leaderBardUI;
    [SerializeField] private GameObject _loginAttention;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private GameObject _scrollBar;

    private void OnEnable()
    {
        UpdateLeaderBoard();
    }

    public void LoginUser()
    {
#if !UNITY_EDITOR
        PlayerAccount.Authorize(() => LoadEntries());
#endif
    }

    public void UpdateLeaderBoard()
    {
        gameObject.SetActive(true);
#if !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
        {    
            LoadEntries();
        }
#endif
    }

    private void LoadEntries()
    {
        _loginAttention.SetActive(false);
        _scrollRect.enabled = true;
        _scrollBar.SetActive(true);
        int playerRank = 0;

        Leaderboard.GetPlayerEntry("LeaderBoard", (result) =>
        {
            if (result == null)
                Debug.Log("Player is not present in the leaderboard.");
            else
                playerRank = result.rank;        
        });

        LeaderboardEntryResponse[] entries;

        Leaderboard.GetEntries(leaderboardName: "LeaderBoard", topPlayersCount: 3, competingPlayersCount: 3, onSuccessCallback: (result) =>
        {
            entries = result.entries;
            _leaderBardUI.ClearUIElements();

            for (int i = 0; i < entries.Length; i++)
            {
                if(i == 3) _leaderBardUI.SpawnSepataror();
                var entry = entries[i];
                string name = entry.player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Player";
                _leaderBardUI.SpawnUIElement(name, entry.score, entry.rank, entry.player.profilePicture, entry.rank == playerRank);
            }

        });
    }
}

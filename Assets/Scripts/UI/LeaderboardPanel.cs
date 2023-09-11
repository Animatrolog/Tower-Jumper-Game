using UnityEngine;
using Agava.YandexGames;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private LeaderBoardUIManager _leaderBardUI;
    [SerializeField] private GameObject _loginAttention;

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
        int playerRank = 0;

        Leaderboard.GetPlayerEntry("LeaderBoard", (result) =>
        {
            if (result == null)
                Debug.Log("Player is not present in the leaderboard.");
            else
                playerRank = result.rank;        
        });

        LeaderboardEntryResponse[] entries;

        Leaderboard.GetEntries("LeaderBoard", (result) =>
        {
            entries = result.entries;
            _leaderBardUI.ClearUIElements();
            for (int i = 0; i < 3; i++)
            {
                if (i > entries.Length - 1) return;
                var entry = entries[i];
                string name = entry.player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Player";
                _leaderBardUI.SpawnUIElement(name, entry.score, entry.rank, entry.player.profilePicture, entry.rank == playerRank);
            }

            if (entries.Length < 4) return;

            _leaderBardUI.SpawnSepataror();

            int startIndex = Mathf.Clamp(playerRank - 2, 3, entries.Length - 1);

            for (int i = startIndex; i <= playerRank + 1; i++)
            {
                if (i > entries.Length - 1) return;
                var entry = entries[i];
                string name = entry.player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Player";
                _leaderBardUI.SpawnUIElement(name, entry.score, entry.rank, entry.player.profilePicture, entry.rank == playerRank);
            }
        });
    }
}

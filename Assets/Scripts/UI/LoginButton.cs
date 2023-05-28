using Agava.YandexGames;
using TMPro;
using UnityEngine;

public class LoginButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private TextMeshProUGUI _playerIdText;
    [SerializeField] private TextMeshProUGUI _nickNameText;

    public void LoginUser()
    {
        _textMeshPro.text = "Logged in";
        PlayerAccount.GetProfileData((result) =>
        {
            string name = result.publicName;
            if (string.IsNullOrEmpty(name))
                name = "Anonymous";
            _nickNameText.text = name;
            _playerIdText.text = result.uniqueID; ;
        });
    }
}

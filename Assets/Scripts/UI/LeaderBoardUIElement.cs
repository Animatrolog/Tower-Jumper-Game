using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardUIElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _userNameText;
    [SerializeField] private TextMeshProUGUI _userScoreText;
    [SerializeField] private TextMeshProUGUI _placeText;
    [SerializeField] private URLImage _userPic;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Color _playerBackgroundColor;

    public void Initialize(string userName, int userScore, int place, string picURL, bool isPlayer = false)
    {
        _userNameText.text = userName;
        _userScoreText.text = userScore.ToString();
         _placeText.text = (place > 0)? place.ToString() : "";
        _userPic.SetImageFromURL(picURL);
        if(isPlayer) _backgroundImage.color = _playerBackgroundColor;
    }
}

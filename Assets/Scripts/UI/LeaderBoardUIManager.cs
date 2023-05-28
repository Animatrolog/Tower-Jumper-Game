using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardUIManager : MonoBehaviour
{
    [SerializeField] private LeaderBoardUIElement _uIElementPrefab;
    [SerializeField] private GameObject _separatorPrefab;

    private GameObject _separator;
    private List<LeaderBoardUIElement> _uIElements = new List<LeaderBoardUIElement>();

    public void SpawnSepataror()
    {
        _separator = Instantiate(_separatorPrefab, transform);
    }

    public void SpawnUIElement(string userName, int userScore, int userRank, string picURL, bool isPlayer)
    {
        var uIElement = Instantiate(_uIElementPrefab, transform);
        _uIElements.Add(uIElement);
        uIElement.Initialize(userName, userScore, userRank, picURL, isPlayer );
    }

    public void ClearUIElements()
    {
        foreach (LeaderBoardUIElement element in _uIElements)
        {
            Destroy(element.gameObject);
        }
        if(_separator) Destroy(_separator);
        _uIElements = new List<LeaderBoardUIElement>();
    }
}

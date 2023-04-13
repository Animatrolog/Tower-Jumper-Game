using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _additionalNumber;
    [SerializeField] private MultiLangSO _prefix;

    private GameDataManager _gameDataManager;

    void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        if(_prefix != null)
            _text.text = _prefix.GetText(LanguageManager.Instance.Language) + (_gameDataManager.Level + _additionalNumber);
        else
            _text.text = (_gameDataManager.Level + _additionalNumber).ToString();
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "ML_Text", menuName = "Localization/Text")]
public class MultiLangSO : ScriptableObject
{
    [SerializeField] private string _textEn;
    [SerializeField] private string _textRu;

    public string GetText(string lang = "en")
    {
        switch (lang)
        {
            case "en": return _textEn;
            case "ru": return _textRu; 
            default: return _textEn; 
        }
    }
}


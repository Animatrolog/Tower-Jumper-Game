using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MultiLanguageText : MonoBehaviour
{
    [SerializeField] private MultiLangSO _multiLangSO;

    private TextMeshProUGUI _textMeshProUGUI;

    private void Start()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI.text = _multiLangSO.GetText(LanguageManager.Instance.Language);
    }
}

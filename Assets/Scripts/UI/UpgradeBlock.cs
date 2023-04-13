using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBlock : MonoBehaviour
{
    [SerializeField] private TMP_Text _requiredText;
    [SerializeField] private GameObject _disabledImage;
    [SerializeField] private Button _upgrdeButton;
    [SerializeField] private GameObject _rewardedPanel;

    [SerializeField] private MultiLangSO _levelMLSO;
    [SerializeField] private MultiLangSO _requiredMLSO;
    [SerializeField] private MultiLangSO _notEnoughCoinsMLSO;

    public void SetBlock(bool hasEnoughCoins, bool hasEnoughLevel, int requiredLevel)
    {
        string language = LanguageManager.Instance.Language;    
        bool canUpgrade = hasEnoughCoins && hasEnoughLevel;

        _upgrdeButton.interactable = canUpgrade;
        _disabledImage.SetActive(!canUpgrade);

        _rewardedPanel.SetActive(hasEnoughLevel && !hasEnoughCoins);

        if (!hasEnoughLevel)
            _requiredText.text = (_levelMLSO.GetText(language) + requiredLevel + _requiredMLSO.GetText(language));
        else
            _requiredText.text = _notEnoughCoinsMLSO.GetText(language);
    }

}

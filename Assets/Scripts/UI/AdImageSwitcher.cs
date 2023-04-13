using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdImageSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _priceImage;
    [SerializeField] private Sprite _adSprite;
    [SerializeField] private Sprite _coinSprite;
    [SerializeField] private MultiLangSO _watchAdMLSO;
    [SerializeField] private MultiLangSO _freeAdMLSO;

    public void SetRewarded(bool isRewarded, int price = 0)
    {
        string language = LanguageManager.Instance.Language;

        if(isRewarded)
        {
            _priceText.text = _watchAdMLSO.GetText(language);
            _priceImage.sprite = _adSprite;
        }
        else
        {
            if (price == 0) _priceText.text = _freeAdMLSO.GetText(language);
            else _priceText.text = price.ToString();
            _priceImage.sprite = _coinSprite;
        }
    }
}

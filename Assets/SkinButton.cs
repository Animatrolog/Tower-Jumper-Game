using TMPro;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    private PlayerSkinManager _skinManager;
    private int _skinID;
    [SerializeField] private Transform _modelContainer;
    [SerializeField] private TextMeshProUGUI _nameText;

    private void Start()
    {
        _skinManager = PlayerSkinManager.Instance;
    }

    public void Initialize(int skinID, SkinSO skin)
    {
        _skinID = skinID;
        GameObject model = Instantiate(skin.Model, _modelContainer);
        model.layer = 5;
        _nameText.text = skin.SkinName.GetText(LanguageManager.Instance.Language);
    }

    public void OnClick()
    {
        _skinManager.ChangeSkin(_skinID);
    }
}

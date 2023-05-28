using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    private int _skinID;
    [SerializeField] private RawImage _icon;

    public void Initialize(int skinID, Skin skin)
    {
        _skinID = skinID;
        if (GameDataManager.Instance.GameSaveData.UnlockedSkins.Contains(_skinID))
            _icon.texture = skin.Icon;
    }

    public void OnClick()
    {
        if (GameDataManager.Instance.GameSaveData.UnlockedSkins.Contains(_skinID))
            PlayerSkinManager.Instance.ChangeSkin(_skinID);
    }
}

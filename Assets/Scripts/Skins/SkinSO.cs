using UnityEngine;

[CreateAssetMenu(fileName = "New_Skin", menuName = "Items/Skin")]
public class SkinSO : ScriptableObject
{
    [SerializeField] private GameObject _model;
    [SerializeField] private MultiLangSO _skinName;

    public GameObject Model => _model;
    public MultiLangSO SkinName => _skinName;
}

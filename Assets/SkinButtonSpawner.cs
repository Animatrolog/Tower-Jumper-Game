using System.Collections.Generic;
using UnityEngine;

public class SkinButtonSpawner : MonoBehaviour
{
    [SerializeField] private SkinButton _buttonPrefab;

    private PlayerSkinManager _skinManager;

    private void Awake()
    {
        _skinManager = PlayerSkinManager.Instance;
    }

    private void Start()
    {
        List<SkinSO> skins = _skinManager.Skins;
        
        for ( int i = 0; i < skins.Count; i++)
        {
            SkinButton button = Instantiate(_buttonPrefab, transform);
            button.Initialize(i, skins[i]);
        }
    }
}

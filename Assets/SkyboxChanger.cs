using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    [SerializeField] private Material[] _skyboxMaterials;
    private GameDataManager _gameDataManager;

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        ChangeSkybox(_gameDataManager.Level - 1);
    }

    public void ChangeSkybox(int skyboxID)
    {
        //skyboxID = skyboxID / 10;
        skyboxID = Mathf.Clamp(skyboxID, 0, _skyboxMaterials.Length - 1); 
        RenderSettings.skybox = _skyboxMaterials[skyboxID];
    }
}

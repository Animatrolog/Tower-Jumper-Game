using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnvironmentChanger : MonoBehaviour
{
    [SerializeField] private List<EnvironmentPreset> _environmentPresets;
    [SerializeField] private Transform _directLightTransform;
    [SerializeField] private int _changePeriod;

    private GameDataManager _gameDataManager;

    private void OnEnable()
    {
        _gameDataManager = GameDataManager.Instance;
        ChangeSkybox((_gameDataManager.Level - 1) / _changePeriod);
    }

    public void ChangeSkybox(int presetId)
    {
        if (presetId > _environmentPresets.Count - 1)
        {
            int hueta = (int)(Mathf.Floor(presetId / _environmentPresets.Count) * _environmentPresets.Count);
            presetId -= hueta;
            Debug.Log("index" + presetId + " - " + hueta);
        }

        EnvironmentPreset preset = _environmentPresets[presetId];
        RenderSettings.skybox = preset.SkyboxMaterial;
        RenderSettings.ambientIntensity = preset.SkyboxLightIntensity;
        _directLightTransform.rotation = Quaternion.Euler(preset.DirectLightRotation);
        Light directLight = _directLightTransform.GetComponent<Light>();
        directLight.intensity = preset.DirectLightIntensity;
        directLight.color = preset.DirectLightColor;
        DynamicGI.UpdateEnvironment();
    }
}

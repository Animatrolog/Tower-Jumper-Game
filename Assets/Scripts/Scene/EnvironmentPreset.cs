using UnityEngine;

[CreateAssetMenu(fileName = "NewEnvironmentPreset", menuName = "Environment/EnvironmentPreset")]
public class EnvironmentPreset : ScriptableObject
{
    [SerializeField] private Material _skyboxMaterial;
    [SerializeField] private float _skyboxLightIntensity;
    [SerializeField] private Vector3 _directLightRotation;
    [SerializeField] private Color _directLightColor;
    [SerializeField] private float _directLightIntensity;

    public Material SkyboxMaterial => _skyboxMaterial;
    public float SkyboxLightIntensity => _skyboxLightIntensity;
    public Vector3 DirectLightRotation => _directLightRotation;
    public Color DirectLightColor => _directLightColor;
    public float DirectLightIntensity => _directLightIntensity;
}

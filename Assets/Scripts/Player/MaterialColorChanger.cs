using UnityEngine;

public class MaterialColorChanger : MonoBehaviour
{
    [SerializeField] private Color _playerColor;
    [SerializeField] private Material _material;

    public Color CrowdColor => _playerColor;

    private void Awake()
    {
        SetColor(_playerColor);
    }

    public void SetColor(Color color)
    {
        _material.color = color;
    }
}

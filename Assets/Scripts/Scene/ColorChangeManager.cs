using UnityEngine;
using UnityEngine.Events;

public class ColorChangeManager : MonoBehaviour
{
    [SerializeField] private MaterialColorChanger _colorChanger;
    [SerializeField] private Color _interfaceColor;

    public UnityAction<Color> OnColorChange;
    public static ColorChangeManager Instance;
    public Color InterfaceColor => _interfaceColor;

    private void Awake()
    {
        Instance = this;
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RainbowColor : MonoBehaviour
{
    [SerializeField] private List<TextMeshPro> _textMeshes; 

    public void SetColor(int index, float step)
    {
        Color color = Color.HSVToRGB(index * step, 1.0f, 1.0f);
        foreach (Transform child in GetComponentInChildren<Transform>(true))
        {
            child.GetComponent<Renderer>().material.color = color;
        }

        foreach (TextMeshPro text in _textMeshes)
        {
            text.text = "X" + ((index * 0.1) + 1).ToString(); 
        }
    }
}

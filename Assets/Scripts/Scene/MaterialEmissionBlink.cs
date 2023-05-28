using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionBlink : MonoBehaviour
{
    [SerializeField] float _blinkFrequency = 1f;
    [SerializeField] List<Material> _materials;

    void Update()
    {
        float timeSin = (Mathf.Sin( Time.time * _blinkFrequency));

        timeSin = (timeSin + 1f) / 2f; // remap -1 .. 1 to 0 .. 1

        foreach (Material material in _materials)
        {
            material.SetColor("_EmissionColor", material.color * timeSin);
        }    
    }
}

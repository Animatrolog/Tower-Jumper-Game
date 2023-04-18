using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private TextMeshProUGUI _speedText;
    [SerializeField] private Slider _speedSlider;

    void Update()
    {
        float magnitude = _rigidbody.velocity.magnitude;
        _speedSlider.value = (magnitude * 3.6f);
        _speedText.text = ((int)(magnitude * 3.6f)).ToString();
    }
}

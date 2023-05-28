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
        _speedSlider.value = magnitude;
        _speedText.text = ((int)(magnitude)).ToString();
    }
}

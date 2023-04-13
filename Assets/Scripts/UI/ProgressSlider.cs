using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _finishTransform;
    [SerializeField] private Slider _slider;

    void Start()
    {
        _slider.maxValue = -_finishTransform.position.y;
      
    }

    private void UpdateProgress()
    {
        _slider.value = -_playerTransform.position.y;
    }

    void Update()
    {
        UpdateProgress();
    }
}

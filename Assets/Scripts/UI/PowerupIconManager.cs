using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupIconManager : MonoBehaviour
{
    [SerializeField] private Image _powerupIconPrefab;

    private Dictionary<Powerup, Image> _images = new Dictionary<Powerup, Image>();

    public void ShowPowerupIcon(Powerup powerup) 
    {
        _images[powerup] = (Instantiate(_powerupIconPrefab, transform));
        powerup.OnProgressChanged += UpdateSliderValue;
        _images[powerup].sprite = powerup.Icon;
    }

    public void HidePowerupIcon(Powerup powerup)
    {
        Destroy(_images[powerup].gameObject);
        powerup.OnProgressChanged -= UpdateSliderValue;
    }

    private void UpdateSliderValue(Powerup powerup)
    {
        _images[powerup].GetComponent<Slider>().value = 1 - powerup.Progress;
    }

}

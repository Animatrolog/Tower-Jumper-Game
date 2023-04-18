using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupIconManager : MonoBehaviour
{
    [SerializeField] private PowerUps _powerUps;
    [SerializeField] private Image _powerUpIcon;
    
    private Dictionary<PowerUp, Image> _images = new Dictionary<PowerUp, Image>();

    private void OnEnable()
    {
        _powerUps.OnPowerUp += ShowPowerUpIcon;
        _powerUps.OnPowerUpCanceled += HidePowerUpIcon;
    }

    private void OnDisable()
    {
        _powerUps.OnPowerUp -= ShowPowerUpIcon;
        _powerUps.OnPowerUpCanceled -= HidePowerUpIcon;
    }

    private void ShowPowerUpIcon(PowerUp powerUp) 
    {
        _images[powerUp] = Instantiate(_powerUpIcon, transform);
        _images[powerUp].sprite = powerUp.Icon;
        if(powerUp.Duration > 0)
        { }
    }

    private void HidePowerUpIcon(PowerUp powerUp)
    {
        Destroy(_images[powerUp].gameObject);
    }
}

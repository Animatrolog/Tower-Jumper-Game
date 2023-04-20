using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private PowerupIconManager _iconManager;
    [SerializeField] private List<Powerup> _powerups = new List<Powerup>();

    public UnityAction<PowerupHolder> OnPowerUp;
    public UnityAction<PowerupHolder> OnPowerUpCanceled;
    public List<Powerup> Powerups => _powerups;

    public static PowerupManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPowerUp(int powerupId)
    {
        if (_powerups[powerupId].IsActive)
        {
            _powerups[powerupId].Progress = 0f;
            return;
        }
        _powerups[powerupId].ActivatePowerUp(_ball);
        _iconManager.ShowPowerupIcon(_powerups[powerupId]);
        _powerups[powerupId].OnPowerupCanceled += CancelPowerup;
    }

    private void CancelPowerup(Powerup powerup)
    {
        int index = _powerups.IndexOf(powerup);
        _powerups[index].OnPowerupCanceled -= CancelPowerup;
        _iconManager.HidePowerupIcon(powerup);
    }
}

public enum PowerupType
{
    Shield = 0,
    Boost = 1,
    SlowMo = 2,
}
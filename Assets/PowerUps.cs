using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private BallDamage _ballDamage;
    [SerializeField] private MeteorMode _meteorMode;

    private List<PowerUpType> _powerUpList = new List<PowerUpType>();

    public UnityAction<PowerUp> OnPowerUp;
    public UnityAction<PowerUp> OnPowerUpCanceled;
    public List<PowerUpType> PowerUpList => _powerUpList;
    public static PowerUps Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool AddPowerUp(PowerUp powerUp)
    {
        if (_powerUpList.Contains(powerUp.Type)) return false;
        _powerUpList.Add(powerUp.Type);
        OnPowerUp?.Invoke(powerUp);
        
        switch (powerUp.Type)
        {
            case PowerUpType.Shield:
                _ballDamage.AddShield(powerUp);
                _ballDamage.OnShieldCanceled += CancelPowerUp;
                break;
            case PowerUpType.Boost:
                _meteorMode.ForceMeteorMode(powerUp);
                _meteorMode.OnMeteorCanceled += CancelPowerUp;
                break;
            case PowerUpType.SlowMo:
                StartCoroutine(SlowMoCoroutine(powerUp));
                //_meteorMode.OnMeteorCanceled += CancelPowerUp;
                break;
        }
        return true;
    }

    private IEnumerator SlowMoCoroutine(PowerUp powerUp)
    {
        TimeScaler.SetTimeScale(0.6f);
        yield return new WaitForSecondsRealtime(6);
        if (GameStateManager.CurrentGameState == GameState.Game) TimeScaler.SetTimeScale(1f);
        CancelPowerUp(powerUp);
    }

    private void CancelPowerUp(PowerUp powerUp)
    {
        _powerUpList.Remove(powerUp.Type);
        OnPowerUpCanceled?.Invoke(powerUp);
    }
}

public enum PowerUpType
{
    Shield = 0,
    Boost = 1,
    SlowMo = 2,
}
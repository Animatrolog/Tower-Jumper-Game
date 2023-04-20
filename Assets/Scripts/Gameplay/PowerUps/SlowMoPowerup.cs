using UnityEngine;

public class SlowMoPowerup : Powerup
{
    [SerializeField] private float _timeScale;

    private void Awake()
    {
        _duration *= _timeScale;
    }

    public override void ActivatePowerUp(Ball targetBall)
    {
        TimeScaler.SetTimeScale(_timeScale);

        base.ActivatePowerUp(targetBall);
    }

    protected override void DeactivatePowerUp()
    {
        if (GameStateManager.CurrentGameState == GameState.Game) 
            TimeScaler.SetTimeScale(1f);

        base.DeactivatePowerUp();
    }
}

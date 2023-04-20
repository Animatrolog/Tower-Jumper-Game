public class BoostPowerup : Powerup
{
    MeteorMode _meteorMode;

    public override void ActivatePowerUp(Ball targetBall)
    {
        _meteorMode = targetBall.GetComponent<MeteorMode>();
        _meteorMode.ForceMeteorMode();

        base.ActivatePowerUp(targetBall);
    }

    protected override void DeactivatePowerUp()
    {
        _meteorMode.ResetMeteorMode();

        base.DeactivatePowerUp();
    }
}

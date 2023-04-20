public class ShieldPowerup : Powerup
{
    BallDamage _ballDamage;

    public override void ActivatePowerUp(Ball targetBall)
    {
        _ballDamage = targetBall.GetComponent<BallDamage>();
        _ballDamage.HasShield = true;
        _ballDamage.OnShieldBreak += DeactivatePowerUp;

        base.ActivatePowerUp(targetBall);
    }

    protected override void DeactivatePowerUp()
    {
        _ballDamage.HasShield = false;
        _ballDamage.OnShieldBreak -= DeactivatePowerUp;

        base.DeactivatePowerUp();
    }
}

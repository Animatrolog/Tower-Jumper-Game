using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Powerup : MonoBehaviour
{
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected float _duration;

    [HideInInspector] public float Progress;
    public bool IsActive { get; protected set; }
    public float Duration => _duration;
    public Sprite Icon => _icon;
    public UnityAction<Powerup> OnPowerupCanceled;
    public UnityAction<Powerup> OnProgressChanged;

    public virtual void ActivatePowerUp(Ball targetBall)
    {
        Progress = 0f;
        StartCoroutine(PowerupCoroutine());
        IsActive = true;
    }

    protected virtual void DeactivatePowerUp()
    {
        StopAllCoroutines();
        OnPowerupCanceled?.Invoke(this);
        IsActive = false;
    }

    protected IEnumerator PowerupCoroutine()
    {
        while (Progress <= 1)
        {
            Progress += Time.deltaTime / Duration;
            OnProgressChanged?.Invoke(this);
            yield return null;
        }
        DeactivatePowerUp();
    }
}

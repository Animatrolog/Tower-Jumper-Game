using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class MeteorMode : MonoBehaviour
{
    [SerializeField] private float _meteorThreshold;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _velocityBreakFactor;
    [SerializeField] private BallJump _jump;

    public float VelocityBreakFactor => _velocityBreakFactor;
    private Rigidbody _rigidbody;

    public UnityAction OnMeteorMode;
    public UnityAction<PowerUp> OnMeteorCanceled;
    public Vector3 LastVelocity { get; private set; }
    public bool IsMeteorMode { get; private set; }
    private bool _foreceMeteorMode;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        SetMeteorMode(_rigidbody.velocity.magnitude > _meteorThreshold || _foreceMeteorMode);
    }

    private void SetMeteorMode(bool state)
    {
        if (state == IsMeteorMode) return;
        IsMeteorMode = state;
        if (state) OnMeteorMode?.Invoke();
        PlayParticles(state);

    }

    public void ForceMeteorMode(PowerUp powerUp)
    {
        StartCoroutine(ForceMeteorCoroutine(powerUp));
    }

    private IEnumerator ForceMeteorCoroutine(PowerUp powerUp)
    {
        _jump.CancelJump();
        float cachedFactor = _velocityBreakFactor;
        _velocityBreakFactor = 1f;
        _foreceMeteorMode = true;
        yield return new WaitForSeconds(powerUp.Duration);
        _velocityBreakFactor = cachedFactor;
        _rigidbody.velocity = Vector3.down * 5f;
        OnMeteorCanceled?.Invoke(powerUp);
        _foreceMeteorMode = false;
    }

    private void PlayParticles(bool state)
    {
        if (state) _particleSystem.Play();
        else _particleSystem.Stop();
    }
}

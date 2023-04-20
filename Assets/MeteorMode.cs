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
    public UnityAction OnMeteorCanceled;
    public Vector3 LastVelocity { get; private set; }
    public bool IsMeteorMode { get; private set; }
    private bool _foreceMeteorMode;
    private float _originalBreakFactor;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _originalBreakFactor = _velocityBreakFactor;
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

    public void ForceMeteorMode()
    {
        _jump.CancelJump();
        _velocityBreakFactor = 1f;
        _foreceMeteorMode = true;
    }

    public void ResetMeteorMode()
    {
        _velocityBreakFactor = _originalBreakFactor;
        _rigidbody.velocity = Vector3.down * 5f;
        OnMeteorCanceled?.Invoke();
        _foreceMeteorMode = false;
    }

    private void PlayParticles(bool state)
    {
        if (state) _particleSystem.Play();
        else _particleSystem.Stop();
    }
}

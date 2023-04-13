using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class MeteorMode : MonoBehaviour
{
    [SerializeField] private float _meteorThreshold;
    [SerializeField] private ParticleSystem _particleSystem;

    private Rigidbody _rigidbody;

    public UnityAction OnMeteorMode;
    public Vector3 LastVelocity { get; private set; }
    public bool IsMeteorMode { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        LastVelocity = _rigidbody.velocity;

        if(LastVelocity.magnitude > _meteorThreshold != IsMeteorMode)
        {
            IsMeteorMode = LastVelocity.magnitude > _meteorThreshold;
            if (IsMeteorMode) OnMeteorMode?.Invoke();
            PlayParticles(IsMeteorMode);
        }
    }

    private void PlayParticles(bool state)
    {
        if (state) _particleSystem.Play();
        else _particleSystem.Stop();
    }
}

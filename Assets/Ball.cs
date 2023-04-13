using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Vector3 LastFixedPosition { get; private set; }
    public Vector3 LastFixedVelocity { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        LastFixedPosition = transform.position;
        LastFixedVelocity = _rigidbody.velocity;
    }
}

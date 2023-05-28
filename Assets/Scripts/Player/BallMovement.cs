using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Transform _center;
    public float TargetAngle;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
 
    private void FixedUpdate()
    {
        MoveAround();
    }

    public void MoveAround()
    {
        Quaternion targetRotation = Quaternion.Euler(0, TargetAngle, 0);
        _rigidbody.MoveRotation(targetRotation);

        Vector3 targetPosition = targetRotation * (Vector3.forward * 3);
        targetPosition.Set(targetPosition.x, transform.position.y, targetPosition.z);
        _rigidbody.MovePosition(targetPosition);
    }
}

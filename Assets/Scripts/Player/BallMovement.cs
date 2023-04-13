using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Transform _center;
    public float MoveSpeed = 1f;
    public Vector3 CrowdDirection { get; protected set; }
    public Vector3 TargetPosition;

    private void Start()
    {
        TargetPosition = transform.position;
        CrowdDirection = transform.forward * 0.1f;
    }

    private void Update()
    {
        MoveAround();
    }

    public void MoveAround()
    {
        Vector3 horisontalPosition = Vector3.Scale(transform.position, new(1,0,1));
        Vector3 targetPosition = Vector3.Scale(TargetPosition, new(1, 0, 1));
        transform.RotateAround(_center.position, Vector3.up, Vector3.SignedAngle(horisontalPosition, targetPosition, Vector3.up));
    }
}

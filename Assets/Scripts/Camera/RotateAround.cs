using TMPro;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private Transform _center;

    void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.Scale(_objectToFollow.position, new(1,0,1));
        Vector3 selfPosition = Vector3.Scale(transform.position, new(1, 0, 1));     
        float angle = Vector3.SignedAngle(selfPosition,targetPosition, Vector3.up);
        transform.RotateAround(_center.position, Vector3.up, angle);
    }
}


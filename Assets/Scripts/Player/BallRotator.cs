using UnityEngine;

public class BallRotator : MonoBehaviour
{
    private void Update()
    {
        float angle = GetAngleFromCenter(transform.position);
        transform.localRotation = Quaternion.Euler(0, 0, -angle);
    }

    private float GetAngleFromCenter(Vector3 position)
    {
        position.Set(position.x, 0f, position.z);
        return Vector3.SignedAngle(Vector3.forward, position, Vector3.up); ;
    }
}

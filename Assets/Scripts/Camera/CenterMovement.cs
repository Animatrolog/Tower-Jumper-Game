using UnityEngine;

public class CenterMovement : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    void LateUpdate()
    {
        if(_ball.position.y < transform.position.y)
            transform.position = new(transform.position.x, _ball.position.y, transform.position.z);
    }
}

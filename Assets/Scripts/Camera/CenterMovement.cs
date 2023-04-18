using UnityEngine;

public class CenterMovement : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    void Update()
    {
        if(_ball.position.y < transform.position.y)
            transform.Translate(((_ball.position.y - transform.position.y) * Vector3.up));
    }
}

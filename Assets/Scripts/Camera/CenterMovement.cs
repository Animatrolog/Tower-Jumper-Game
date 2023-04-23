using UnityEngine;

public class CenterMovement : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    void Update()
    {
        var piecePosition = _ball.position;
        if (piecePosition.y  < transform.position.y)
            transform.Translate((piecePosition.y - transform.position.y) * Vector3.up);
    }
}

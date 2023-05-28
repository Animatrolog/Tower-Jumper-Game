using UnityEngine;

public class CenterMovement : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    float _lowerstPoint = 0;

    void Update()
    {
        if(_lowerstPoint > _ball.transform.position.y)
            _lowerstPoint = _ball.transform.position.y;
        transform.position = Vector3.Lerp(transform.position, _lowerstPoint * Vector3.up, Time.deltaTime * 20f);
    }
}

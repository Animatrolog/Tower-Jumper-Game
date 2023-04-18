using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotationAxis;

    private void Update()
    {
        if (_speed != 0 || _rotationAxis != Vector3.zero)
            transform.Rotate(_rotationAxis, Time.deltaTime * _speed);
    }

    public void Initialize(Vector3 ratationAxis, float speed)
    {
        _speed = speed;
        _rotationAxis = ratationAxis;
    }

}

public enum RotationAxis
{
    Up = 0,
    Right = 1,
    Froward = 2
}

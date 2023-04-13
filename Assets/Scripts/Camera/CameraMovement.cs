using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private float _speed;
    [SerializeField] private float _minXPosition;
    [SerializeField] private float _maxXPosition;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _objectToFollow.position;
    }

    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = _objectToFollow.position + _offset - transform.position;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, _minXPosition, _maxXPosition), targetPosition.y, targetPosition.z);

        var moveDirection = _speed * targetPosition;

        transform.Translate(Time.deltaTime * moveDirection);
    }
}
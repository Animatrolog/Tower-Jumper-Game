using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Camera _camera;
    [SerializeField] private BallMovement _crowd;
    public float Sensitivity;

    private Transform _crowdTransform;
    private float _xDeltaPos;

    private void Start()
    {
        _crowdTransform = (_crowd as MonoBehaviour).transform;
        _xDeltaPos = Input.mousePosition.x;
    }

    void Update()
    {
        HandleInput();
    }

    private float _angle;
    public void HandleInput()
    {
        if (Input.GetMouseButton(0))
        {
            _xDeltaPos = Input.mousePosition.x - _xDeltaPos;
            
            if (Input.GetMouseButtonDown(0))
            {
                _xDeltaPos = 0;
            }

            if (_xDeltaPos != 0)
            {
                float screenWidth = Screen.width;
                float aspectRatio = screenWidth / Screen.height;
                _angle += (_xDeltaPos / Screen.width) * 360f * Sensitivity * aspectRatio;
            }

            _xDeltaPos = Input.mousePosition.x;
        }
        _crowd.TargetAngle = _angle;
    }
}

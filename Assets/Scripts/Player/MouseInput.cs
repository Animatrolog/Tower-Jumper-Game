using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Camera _camera;
    [SerializeField] private BallMovement _crowd;
    public float Sensitivity;

    private Transform _cameraTransform;
    private Transform _crowdTransform;
    private float _xDeltaPos;

    private void Start()
    {
        _cameraTransform = _camera.transform;
        _crowdTransform = (_crowd as MonoBehaviour).transform;
        _xDeltaPos = Input.mousePosition.x;
    }

    void Update()
    {
        HandleInput();
    }


    public void HandleInput()
    {
        float angle = 0f;
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
                angle = (_xDeltaPos / Screen.width) * 360f * Sensitivity * aspectRatio;
            }

            _xDeltaPos = Input.mousePosition.x;
        }
        Vector3 crowdPosition = Vector3.Scale(_crowdTransform.position, new(1, 0, 1));

        _crowd.TargetPosition = Quaternion.Euler(0, angle, 0) * (crowdPosition.normalized * _radius);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallJump : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private Transform _animatedTransform;

    private Rigidbody _rigidbody;
    private Coroutine _jumpCoroutine;

    public UnityAction OnJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(_jumpCoroutine == null)
        {
            _animatedTransform.localScale = Vector3.one + (_rigidbody.velocity.magnitude * 0.015f * Vector3.up);
        }
    }

    public void Jump() 
    {
        if (_jumpCoroutine == null) _jumpCoroutine = StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        OnJump?.Invoke();
        float progress = 0f;
        while (progress <= 1)
        {
            _rigidbody.velocity = _jumpCurve.Evaluate(progress) * _jumpHeight * Vector3.up;
            _animatedTransform.localScale = new Vector3(_animatedTransform.localScale.x, _scaleCurve.Evaluate(progress), _animatedTransform.localScale.z);
            progress += Time.deltaTime / _jumpDuration;
            yield return null;
        }
        _jumpCoroutine = null;
    }

    public void CancelJump()
    {
        if (_jumpCoroutine == null) return;
        StopCoroutine(_jumpCoroutine);
        _jumpCoroutine = null;
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class BallJump : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private Transform _animatedTransform;

    private Rigidbody _rigidbody;
    private Coroutine _animationCoroutine;

    public UnityAction OnJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        _animationCoroutine ??= StartCoroutine(JumpCoroutine());
    }

    private void Update()
    {
        if(_animationCoroutine == null)
        {
            _animatedTransform.localScale = Vector3.one + (_rigidbody.velocity.magnitude * 0.015f * Vector3.up);
        }
    }

    private IEnumerator JumpCoroutine() 
    {
        OnJump?.Invoke();
        float progress = 0f;
        while(progress <= 1)
        {
            _rigidbody.velocity = (_jumpCurve.Evaluate(progress) * _jumpHeight) * Vector3.up;
            _animatedTransform.localScale = new(_animatedTransform.localScale.x, _scaleCurve.Evaluate(progress), _animatedTransform.localScale.z);
            progress += Time.deltaTime / _jumpDuration;
            yield return null;
        }
        _animationCoroutine = null;
    }

    public void CancelJump()
    {
        if (_animationCoroutine == null) return;
        StopCoroutine(_animationCoroutine);
        _rigidbody.velocity = Vector3.down * 9.81f;
        _animationCoroutine = null;
    }
}

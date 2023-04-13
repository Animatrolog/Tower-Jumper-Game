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

    private Rigidbody _rigidbody;
    private bool _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public UnityAction OnJump;

    public void Jump()
    {
        if (_isJumping) return;
        StartCoroutine(JumpCoroutine());
        OnJump?.Invoke();
    }

    private void Update()
    {
        if(!_isJumping)
        {
            transform.localScale = Vector3.one + (_rigidbody.velocity.magnitude * 0.015f * Vector3.up);
        }
    }

    private IEnumerator JumpCoroutine() 
    {
        _isJumping = true;
        float progress = 0f;
        while(progress <= 1)
        {
            _rigidbody.velocity = (_jumpCurve.Evaluate(progress) * _jumpHeight) * Vector3.up;
            transform.localScale = new(transform.localScale.x, _scaleCurve.Evaluate(progress), transform.localScale.z);
            progress += Time.deltaTime / _jumpDuration;
            yield return null;
        }
        _isJumping= false;
    }
}

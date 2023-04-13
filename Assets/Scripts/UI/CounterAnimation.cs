using System.Collections;
using UnityEngine;

public class CounterAnimation : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 1f;
    [SerializeField] private Vector3 _targetScale;

    private Coroutine _animationCoroutine;

    public void Animate(int count)
    {
        _animationCoroutine ??= StartCoroutine(AnimationCoroutine());
    }

    public IEnumerator AnimationCoroutine()
    {
        Vector3 originalScale = transform.localScale;
        transform.localScale = _targetScale;
  
        while(transform.localScale != originalScale)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, originalScale, Time.unscaledDeltaTime / _animationSpeed);
            yield return null;
        }
        _animationCoroutine = null;
    }
}

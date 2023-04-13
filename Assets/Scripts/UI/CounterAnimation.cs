using System.Threading.Tasks;
using UnityEngine;

public class CounterAnimation : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 1f;
    [SerializeField] private Vector3 _targetScale;

    private bool _isAnimating;

    public async void Animate(int count)
    {
        if(_isAnimating) return;
        Vector3 originalScale = transform.localScale;
        transform.localScale = _targetScale;

        _isAnimating = true;    
        while(transform.localScale != originalScale)
        {
            if(!gameObject) return;
            transform.localScale = Vector3.MoveTowards(transform.localScale, originalScale, Time.unscaledDeltaTime * _animationSpeed);
            await Task.Yield();
        }
        _isAnimating = false;
    }
}

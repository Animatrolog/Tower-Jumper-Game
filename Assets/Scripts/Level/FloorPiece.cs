using UnityEngine;
using UnityEngine.Events;

public class FloorPiece : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private DeadlySliceMaker _deadlySliceMaker;
    [SerializeField] private PowerUpSpawner _powerUpSpawner;
    [SerializeField] private Rotator _rotator;

    public UnityAction OnPieceBreak;
    public UnityAction OnPieceShrink;

    bool _isBreaked;

    public void Initialize(float deadlySliceProbability, float rotatingProbability)
    {
        _deadlySliceMaker.MakeDeadlySlices(deadlySliceProbability);
        _powerUpSpawner.SpawnPowerUp(deadlySliceProbability * 0.5f);
        MakePieceRotate(rotatingProbability * 0.25f);
    }

    private void MakePieceRotate(float probability)
    {
        float roll = Random.Range(0.0f, 1.0f);

        if (roll <= probability)
        {
            _rotator.enabled = true;
            float speed = Random.Range(20f, 90f);
            if (Random.Range(0, 2) > 0) speed *= -1;
            _rotator.Initialize(Vector3.up, speed);
        }
    }

    public void Break()
    {
        if(_isBreaked) return;
        _rotator.enabled = false;
        AnimateSlices("Break");
        OnPieceBreak?.Invoke();
        _isBreaked = true;
    }

    public void Shrink()
    {
        if (_isBreaked) return;
        _rotator.enabled = false;
        AnimateSlices("Shrink");
        OnPieceShrink?.Invoke();
        _isBreaked = true;
    }

    private void AnimateSlices(string stateName)
    {
        Collider[] childColliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in childColliders)
        {
            collider.enabled = false;
        }
        _animator.SetTrigger(stateName);
        _animator.speed = 1f;
    }
}

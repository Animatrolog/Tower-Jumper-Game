using UnityEngine;
using UnityEngine.Events;

public class FloorPiece : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private DeadlySliceMaker _deadlySliceMaker;

    public UnityAction OnPieceBreak;
    public UnityAction OnPieceShrink;

    bool _isBreaked;

    public void Initialize(float deadlySliceProbability, float rotatingProbability)
    {
        _deadlySliceMaker.MakeDeadlySlices(deadlySliceProbability);
        MakePieceRotating(rotatingProbability);
    }

    private void MakePieceRotating(float probability)
    {
        float roll = Random.Range(0.0f, 1.0f);

        if (roll <= probability)
        {
            if(Random.Range(0,2) > 0)
                _animator.Play("DiskRotateCCW");
            else
                _animator.Play("DiskRotateCW");

            _animator.speed = Random.Range(0.25f, 1f); ;
        }
    }

    public void Break()
    {
        if(_isBreaked) return;
        AnimateSlices("Break");
        OnPieceBreak?.Invoke();
        _isBreaked = true;
    }

    public void Shrink()
    {
        if (_isBreaked) return;
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

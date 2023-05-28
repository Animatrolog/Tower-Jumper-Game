using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private  BallJump _ballJump;
    [SerializeField] private GameMode _gameMode;

    private int _combo;

    public UnityAction<int> OnScoreChange;
    public UnityAction<int> OnCombo;
    public UnityAction OnComboBreak;

    public int Score { get; private set; }

    private void OnEnable()
    {
        _gameMode.OnFloorReached += AddCombo;
        _ballJump.OnJump += ResetCombo;
    }

    private void OnDisable()
    {
        _gameMode.OnFloorReached -= AddCombo;
        _ballJump.OnJump -= ResetCombo;
    }

    private void ResetCombo()
    {
        if(_combo > 1)
            OnComboBreak?.Invoke();
        _combo = 0;
    }

    private void AddCombo()
    {
        _combo++;
        Score += _combo;
        OnScoreChange?.Invoke(Score);
        if (_combo > 1)
            OnCombo?.Invoke(_combo);
    }
}

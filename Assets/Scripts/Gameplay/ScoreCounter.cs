using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private ScoreManager _scoreManager;

    public UnityEvent<int> OnAmountUpdated;

    private void OnEnable()
    {
        _scoreManager.OnScoreChange += UpdateCounter;
    }

    private void OnDisable()
    {
        _scoreManager.OnScoreChange -= UpdateCounter;
    }

    private void UpdateCounter(int count)
    {
        _counterText.text = count.ToString();
        OnAmountUpdated?.Invoke(count);
    }
}

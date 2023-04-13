using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ComboCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private ScoreManager _scoreManager;

    public UnityEvent<int> OnAmountUpdated; 

    private void OnEnable()
    {
        _scoreManager.OnCombo += UpdateCounter;
        _scoreManager.OnComboBreak += HideCounter;
    }

    private void OnDisable()
    {
        _scoreManager.OnCombo -= UpdateCounter;
       _scoreManager.OnComboBreak -= HideCounter;
    }

    private void UpdateCounter(int count)
    {
        _counterText.text ="+" + count.ToString();
        OnAmountUpdated?.Invoke(count);
    }

    private void HideCounter()
    {
        _counterText.text = "";
    }
}

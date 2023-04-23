using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Collections;

public class ComboCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private ScoreManager _scoreManager;
    
    private Coroutine _delayCoroutine;

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
        if(_delayCoroutine != null)
            StopCoroutine(_delayCoroutine);
        _counterText.text ="+" + count.ToString();
        OnAmountUpdated?.Invoke(count);
    }

    private void HideCounter()
    {
        _delayCoroutine ??= StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(1);
        _counterText.text = "";
        _delayCoroutine = null;
    }
}

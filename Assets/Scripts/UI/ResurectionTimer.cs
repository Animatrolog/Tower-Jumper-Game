using System.Collections;
using TMPro;
using UnityEngine;

public class ResurectionTimer : MonoBehaviour
{
    [SerializeField] private int _secondsForResurection;
    [SerializeField] private GameObject _resurectButton;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private CounterAnimation _animation;

    void OnEnable()
    {
        CountSeconds();
        StartCoroutine(CountSeconds());
    }
     
    private IEnumerator CountSeconds()
    {
        int timer = _secondsForResurection;

        while (timer > 0)
        {
            _timerText.text = (timer - 1).ToString();
            _animation.Animate(timer - 1);
            yield return new WaitForSecondsRealtime(1);
            timer--;
        }
        if(_resurectButton != null)
            _resurectButton.SetActive(false);
    }
}

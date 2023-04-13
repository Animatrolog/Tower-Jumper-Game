#if UNITY_EDITOR
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialAdEditor : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Text _timerText;
    [SerializeField] private int _time = 3;

    private void OnEnable()
    {
        StartCoroutine(Count());
    }

    private void OnDestroy()
    {
        YaSDK.Instance.SetInterstitialShown();
    }

    private IEnumerator Count()
    {
        int i = 0;
        while (i <= _time)
        {
            _timerText.text = "Рекламу можно закрыть через: " + (_time - i).ToString();
            yield return new WaitForSecondsRealtime(1);
            i++;
        }
        _timerText.gameObject.SetActive(false);
        _closeButton.gameObject.SetActive(true);
    }

    public void CloseAd()
    {
        Destroy(gameObject);
    }
}
#endif
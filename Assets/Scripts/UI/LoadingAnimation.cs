using System.Collections;
using TMPro;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadingText;

    void Start()
    {
        StartCoroutine(AnimationCoroutine());
    }
    

    private IEnumerator AnimationCoroutine()
    {
        while (true) 
        {
            _loadingText.text = "---";
            yield return new WaitForSeconds(0.1f);
            _loadingText.text = "=--";
            yield return new WaitForSeconds(0.1f);
            _loadingText.text = "==-";
            yield return new WaitForSeconds(0.1f);
            _loadingText.text = "===";
            yield return new WaitForSeconds(0.1f);
            _loadingText.text = "-==";
            yield return new WaitForSeconds(0.1f);
            _loadingText.text = "--=";
            yield return new WaitForSeconds(0.1f);
        }
    }
}

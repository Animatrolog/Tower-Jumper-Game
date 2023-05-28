using System.Collections;
using UnityEngine;

public class InterstitialAdTimer : MonoBehaviour
{
    [SerializeField] private int _requestCoolDownTime = 181;

    private Coroutine _adTimerCoroutine;

    public static InterstitialAdTimer Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance == this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public bool TryToStartTimer()
    {
        if (_adTimerCoroutine == null)
        {
            _adTimerCoroutine = StartCoroutine(AdTimerCoroutine());
            return true;
        }
        return false;
    }

    private IEnumerator AdTimerCoroutine()
    {
        for (int i = _requestCoolDownTime; i > 0; i--)
        {
            yield return new WaitForSecondsRealtime(1);
        }
        _adTimerCoroutine = null;
    }
}

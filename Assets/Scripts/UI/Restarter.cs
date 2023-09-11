
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    [SerializeField] private InterstitialAdHandler _interstitialAd;
    
    public void TryToRestart()
    {
        if(_interstitialAd.ShowAd())
            _interstitialAd.OnInterstitialShown += Restart;
        else 
            Restart();
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level");
        TimeScaler.SetTimeScale(1f);
    }
}

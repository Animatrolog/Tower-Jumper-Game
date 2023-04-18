
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
        TimeScaler.SetTimeScale(1f);
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Level");
        TimeScaler.SetTimeScale(1f);
    }
}

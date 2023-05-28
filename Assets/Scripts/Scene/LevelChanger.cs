using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameDataManager.Instance.GameSaveData.Level++;
            SceneManager.LoadScene("Level");
            TimeScaler.SetTimeScale(1f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameDataManager.Instance.GameSaveData.Level--;
            SceneManager.LoadScene("Level");
            TimeScaler.SetTimeScale(1f);
        }
    }
}

using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    private static float _originalTimeScale;
    private static float _originalFixedDeltaTime;

    private void Awake()
    {
        _originalTimeScale = Time.timeScale;
        _originalFixedDeltaTime = Time.fixedDeltaTime;
    }

    public static void SetTimeScale(float newTimeScale)
    {
        Time.timeScale = _originalTimeScale * newTimeScale;
        Time.fixedDeltaTime = _originalFixedDeltaTime * newTimeScale;
    }
}

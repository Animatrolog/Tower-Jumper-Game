using UnityEngine;

public class FpsSettings : MonoBehaviour
{
    [SerializeField] private int _targetFPS = 70;

    void Awake()
    {
        Application.targetFrameRate = _targetFPS;
    }
}

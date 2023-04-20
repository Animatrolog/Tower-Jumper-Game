using UnityEngine;

public class FpsSettings : MonoBehaviour
{
    [SerializeField] private int _targetFPS = 70;

    void Start()
    {
        Application.targetFrameRate = _targetFPS;
    }
}

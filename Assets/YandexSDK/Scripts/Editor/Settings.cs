using UnityEngine;
namespace YandexSDK
{
    public class Settings : ScriptableObject
    {
        [HideInInspector] public string buildPath;
        [HideInInspector] public string projectName;
    }
}

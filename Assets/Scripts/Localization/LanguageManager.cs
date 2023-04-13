using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    [SerializeField] private string _language;

    public string Language 
    {
        get 
        {
            GetLanguage();
            return _language; 
        }
    }

    public static LanguageManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void GetLanguage()
    {
#if UNITY_EDITOR
#else
        _language = YaSDK.Instance.GetLanguage();
#endif
    }
}

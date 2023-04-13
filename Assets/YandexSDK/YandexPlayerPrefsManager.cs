using UnityEngine;
using System.IO;
using System.Linq;

public static class YandexPlayerPrefs
{
    [RuntimeInitializeOnLoadMethod]
    public static void CreateYandexPlayerPrefsManager()
    {
        GameObject yandexPlayerPrefsManager = new GameObject("YandexPlayerPrefsManager");
        YandexPlayerPrefsManager.current = yandexPlayerPrefsManager.AddComponent<YandexPlayerPrefsManager>();
    }
    public static void SetInt(string key, int val)
    {
        if (!YandexPlayerPrefsManager.current.currentSave.intPrefs.ContainsKey(key))
        {
            YandexPlayerPrefsManager.current.currentSave.intPrefs.Add(key, val);
        }
        else
        {
            YandexPlayerPrefsManager.current.currentSave.intPrefs[key] = val;
        }
        YandexPlayerPrefsManager.current.SetSave();
    }
    public static int GetInt(string key, int defVal = 0)
    {
        if (YandexPlayerPrefsManager.current.currentSave.intPrefs.ContainsKey(key))
        {
            return YandexPlayerPrefsManager.current.currentSave.intPrefs.FirstOrDefault(x => x.Key == key).Value;
        }
        else
        {
            return defVal;
        }
    }
    public static void SetString(string key, string val)
    {
        if (!YandexPlayerPrefsManager.current.currentSave.stringPrefs.ContainsKey(key))
        {
            YandexPlayerPrefsManager.current.currentSave.stringPrefs.Add(key, val);
        }
        else
        {
            YandexPlayerPrefsManager.current.currentSave.stringPrefs[key] = val;
        }
        YandexPlayerPrefsManager.current.SetSave();
    }
    public static string GetString(string key, string defVal = "")
    {
        if (YandexPlayerPrefsManager.current.currentSave.stringPrefs.ContainsKey(key))
        {
            return YandexPlayerPrefsManager.current.currentSave.stringPrefs.FirstOrDefault(x => x.Key == key).Value;
        }
        else
        {
            return defVal;
        }
    }
    public static void SetBool(string key, bool val)
    {
        if (!YandexPlayerPrefsManager.current.currentSave.boolPrefs.ContainsKey(key))
        {
            YandexPlayerPrefsManager.current.currentSave.boolPrefs.Add(key, val);
        }
        else
        {
            YandexPlayerPrefsManager.current.currentSave.boolPrefs[key] = val;
        }
        YandexPlayerPrefsManager.current.SetSave();
    }
    public static bool GetBool(string key, bool defVal = false)
    {
        if (YandexPlayerPrefsManager.current.currentSave.boolPrefs.ContainsKey(key))
        {
            return YandexPlayerPrefsManager.current.currentSave.boolPrefs.FirstOrDefault(x => x.Key == key).Value;
        }
        else
        {
            return defVal;
        }
    }
    public static bool HasKey(string key)
    {
        if (YandexPlayerPrefsManager.current.currentSave.boolPrefs.ContainsKey(key) || YandexPlayerPrefsManager.current.currentSave.intPrefs.ContainsKey(key) || YandexPlayerPrefsManager.current.currentSave.stringPrefs.ContainsKey(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
public class YandexPlayerPrefsManager : MonoBehaviour
{
    public static YandexPlayerPrefsManager current;
    public Save currentSave = new Save();
    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
        }
        else
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
#if !UNITY_EDITOR
        YaSDK.Instance.AuthenticateUser();
#else
        if (File.Exists(Path.Combine(Application.dataPath, "save.json")))
        {
            currentSave = JsonUtility.FromJson<Save>(File.ReadAllText(Path.Combine(Application.dataPath, "save.json")));
        }
#endif
    }
    private void OnEnable()
    {
#if !UNITY_EDITOR
        YaSDK.Instance.OnPlayerAuthenticated += GetSave;
        YaSDK.Instance.OnGetPlayerData += OnGetSave;
#endif
    }
    private void OnDisable()
    {
#if !UNITY_EDITOR
        YaSDK.Instance.OnPlayerAuthenticated -= GetSave;
        YaSDK.Instance.OnGetPlayerData -= OnGetSave;
#endif
    }
    private void GetSave()
    {
#if !UNITY_EDITOR
        YaSDK.Instance.GetSave();
#endif
    }
    private void OnGetSave(string save)
    {
        if (save == string.Empty)
        {
            currentSave = new Save();
        }
        else
        {
            currentSave = JsonUtility.FromJson<Save>(save);
        }
    }
    public void SetSave()
    {
#if !UNITY_EDITOR
        YaSDK.Instance.SetSave<Save>(currentSave);
#else
        File.WriteAllText(Path.Combine(Application.dataPath, "save.json"), JsonUtility.ToJson(currentSave));
#endif
    }
    [System.Serializable]
    public class Save
    {
        public StringIntDictionary intPrefs = new StringIntDictionary();
        public StringStringDictionary stringPrefs = new StringStringDictionary();
        public StringBoolDictionary boolPrefs = new StringBoolDictionary();
    }
    [System.Serializable]
    public class StringIntDictionary : SerializableDictionary<string, int> { }
    [System.Serializable]
    public class StringStringDictionary : SerializableDictionary<string, string> { }
    [System.Serializable]
    public class StringBoolDictionary : SerializableDictionary<string, bool> { }
}

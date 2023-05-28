using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartPanelWindowManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _windows;
    [SerializeField] GameObject _defaultPannel;

    public UnityEvent OnAllWindowsClose;

    public bool HasOpenWindows 
    { 
        get 
        {
            foreach (GameObject window in _windows)
            {
                if (window.activeSelf) return true;
            }
            return false;
        } 
    }

    public void CloseAllWindows()
    {
        foreach (GameObject window in _windows) 
        { 
            window.SetActive(false);
        }
        _defaultPannel.SetActive(true);
        OnAllWindowsClose?.Invoke();
    }
}

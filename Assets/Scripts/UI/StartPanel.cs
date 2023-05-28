using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(StartPanelWindowManager))]
public class StartPanel : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent OnPanelTouched;

    private StartPanelWindowManager _windowManager;

    private void Awake()
    {
        _windowManager = GetComponent<StartPanelWindowManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_windowManager.HasOpenWindows)
        {
            _windowManager.CloseAllWindows();
            return;
        }

        GameStateManager.Instance.SetState(GameState.Game);
        OnPanelTouched?.Invoke();
    }

    private void Start()
    {
        TimeScaler.SetTimeScale(1f);
    }
}

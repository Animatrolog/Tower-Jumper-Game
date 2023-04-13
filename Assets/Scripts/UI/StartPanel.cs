using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class StartPanel : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent OnPanelTouched;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameStateManager.Instance.SetState(GameState.Game);
        OnPanelTouched?.Invoke();
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            GameStateManager.Instance.SetState(GameState.Game);
            OnPanelTouched?.Invoke();
        }
    }
}

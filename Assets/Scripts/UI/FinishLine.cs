using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    public UnityEvent OnFinish;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<BallMovement>(out BallMovement ball))
        {
            GameStateManager.Instance.SetState(GameState.Finish);
            OnFinish?.Invoke();
        }  
    } 

}

using UnityEngine;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private DefeatStateTrigger _defeatSateTrigger;
    [SerializeField] private int _lifes = 1;

    public void Damage()
    {
        if (_lifes > 0)
        { 
            _lifes--;
            return;
        }
        Kill();
    }

    private void Kill()
    {
        GetComponent<DefeatStateTrigger>().TriggerDefeatState();
        Time.timeScale = 0f;
    }
}

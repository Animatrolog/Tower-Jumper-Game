using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private DefeatStateTrigger _defeatSateTrigger;
    [SerializeField] private float _cooldown;

    private Coroutine _cooldowdCoroutine;

    public UnityAction OnShieldBreak;

    public bool HasShield;

    public void Damage()
    {
        if (HasShield)
        {
            if(_cooldowdCoroutine == null ) 
                _cooldowdCoroutine = StartCoroutine(CoolDowdCoroutine());
            return;
        }
        Kill();
    }

    private void Kill()
    {
        GetComponent<DefeatStateTrigger>().TriggerDefeatState();
        Time.timeScale = 0f;
    }

    private IEnumerator CoolDowdCoroutine()
    {
        OnShieldBreak?.Invoke();
        yield return new WaitForSeconds(_cooldown);
        HasShield = false;
        _cooldowdCoroutine = null;
    }
}

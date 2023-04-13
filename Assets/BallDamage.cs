using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private DefeatStateTrigger _defeatSateTrigger;
    [SerializeField] private int _lifes = 1;
    [SerializeField] private float _cooldown;

    private Coroutine _cooldowdCoroutine;

    public UnityAction OnDamage;

    public void Damage()
    {
        if (_lifes > 0)
        {
            if (_cooldowdCoroutine == null)
            {
                _lifes--;
                OnDamage?.Invoke();
                _cooldowdCoroutine = StartCoroutine(CoolDowdCoroutine());
            }
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
        yield return new WaitForSeconds(_cooldown);
        _cooldowdCoroutine = null;
    }
}

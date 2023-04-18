using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private DefeatStateTrigger _defeatSateTrigger;
    [SerializeField] private float _cooldown;

    private Coroutine _cooldowdCoroutine;

    public UnityAction OnShieldBreak;
    public UnityAction<PowerUp> OnShieldCanceled;

    private List<PowerUp> _shields = new List<PowerUp>(3);

    public void Damage()
    {
        if (CheckForShields()) return;
        Kill();
    }

    public void AddShield(PowerUp shield)
    {
        _shields.Add(shield);
    }

    private bool CheckForShields()
    {
        bool state = _shields.Count > 0;

        if (state)
        {
            if (_cooldowdCoroutine == null)
            {
                int index = _shields.Count - 1;
                OnShieldCanceled?.Invoke(_shields[index]);
                _shields.RemoveAt(index);
                OnShieldBreak?.Invoke();
                _cooldowdCoroutine = StartCoroutine(CoolDowdCoroutine());
            }
        }
        return state;
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

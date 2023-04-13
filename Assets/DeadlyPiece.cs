using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyPiece : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<DefeatStateTrigger>(out DefeatStateTrigger ball))
        {
            ball.TriggerDefeatState();
        }
    }
}

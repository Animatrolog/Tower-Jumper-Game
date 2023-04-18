using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<PowerUp> _poolOfPowerUps;

    public void SpawnPowerUp(float probability)
    {
        float roll = Random.Range(0f, 1f);

        if (roll > probability / transform.childCount) return;

        int angleRoll = Random.Range(0, 7) * 360;
        int powerUpIndex = Random.Range(0, _poolOfPowerUps.Count);
        int childIndex = Random.Range(0, transform.childCount);

        Instantiate(_poolOfPowerUps[powerUpIndex], transform.GetChild(childIndex));
    }
}

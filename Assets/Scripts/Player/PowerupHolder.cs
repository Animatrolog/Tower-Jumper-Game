using UnityEngine;

public class PowerupHolder : MonoBehaviour
{
    [SerializeField] private PowerupType _powerupType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            PowerupManager.Instance.AddPowerUp((int)_powerupType);
            Destroy(gameObject);
        }
    }
}



using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType _powerUpType;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _duration;

    public PowerUpType Type => _powerUpType;
    public float Duration => _duration;
    public Sprite Icon => _icon;

    private PowerUps _powerUps;

    private void Start()
    {
        _powerUps = PowerUps.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            if (_powerUps.AddPowerUp(this))
                Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            if (_powerUps.AddPowerUp(this))
                Destroy(gameObject);
        }
    }
}


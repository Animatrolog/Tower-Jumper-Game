using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Ball))]
public class JumpTrigger : MonoBehaviour
{
    [SerializeField] private BallJump _jump;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _velocityBreakFactor;
    [SerializeField] private MeteorMode _meteorMode;
    [SerializeField] private BallDamage _damage;

    private Ball _ball;

    public UnityEvent OnPieceBreak;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameStateManager.CurrentGameState == GameState.Defeat) return;

        if (_ball.LastFixedPosition.y < collision.transform.position.y + 0.15f)
        {
            collision.collider.enabled = false;
            _rigidbody.velocity = _ball.LastFixedVelocity;
            return;
        }

        FloorPiece piece = collision.gameObject.GetComponentInParent<FloorPiece>();
        
        if (_meteorMode.IsMeteorMode)
        {
            if (piece == null)
            {
                _jump.Jump();
                return;
            }
            piece.Break();
            OnPieceBreak?.Invoke();
            _rigidbody.velocity = _ball.LastFixedVelocity * _velocityBreakFactor;
            return;
        }

        if (collision.gameObject.CompareTag("Deadly"))
        {
            _damage.Damage();
        }
        _jump.Jump();
    }


}

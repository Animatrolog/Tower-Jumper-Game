using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Ball))]
public class JumpTrigger : MonoBehaviour
{
    [SerializeField] private BallJump _jump;
    [SerializeField] private Rigidbody _rigidbody;
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

        if (_ball.transform.position.y < collision.transform.position.y + 0.15f)
        {
            collision.collider.enabled = false;
            _rigidbody.velocity = _ball.LastFixedVelocity;
            return;
        }

        
        if (_meteorMode.IsMeteorMode)
        {
            FloorPiece piece = collision.gameObject.GetComponentInParent<FloorPiece>();
            piece.Break();
            OnPieceBreak?.Invoke();
            _rigidbody.velocity = _ball.LastFixedVelocity * _meteorMode.VelocityBreakFactor;
            return;
        }

        if (collision.gameObject.CompareTag("Deadly"))
        {
            _damage.Damage();
        }
        _jump.Jump();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_meteorMode.IsMeteorMode)
        {
            FloorPiece piece = collision.gameObject.GetComponentInParent<FloorPiece>();
            piece.Break();
            OnPieceBreak?.Invoke();
            _rigidbody.velocity = _ball.LastFixedVelocity * _meteorMode.VelocityBreakFactor;
            return;
        }
    }

}

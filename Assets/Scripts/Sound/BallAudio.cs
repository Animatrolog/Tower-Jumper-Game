using UnityEngine;

public class BallAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MeteorMode _meteorMode;
    [SerializeField] private BallJump _jump;
    [SerializeField] private BallDamage _damage;
    [SerializeField] private AudioClip _damageClip;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _meteorClip;

    private ScoreManager _combo;

    private void Awake()
    {
        _jump = GetComponent<BallJump>();
    }

    private void OnEnable()
    {
        _damage.OnDamage += PlayDamage;
        _jump.OnJump += PlayJump;
        _meteorMode.OnMeteorMode += PlayMeteor;
    }

    private void OnDisable()
    {
        _damage.OnDamage += PlayDamage;
        _jump.OnJump -= PlayJump;
        _meteorMode.OnMeteorMode -= PlayMeteor;
    }

    private void PlayJump()
    {
        _audioSource.pitch = Random.Range(1.2f, 2.0f);
        _audioSource.clip = _jumpClip;
        _audioSource.Play();
    }

    private void PlayMeteor()
    {
        _audioSource.PlayOneShot(_meteorClip);
    }

    private void PlayDamage()
    {
        _audioSource.PlayOneShot(_damageClip);
    }
}

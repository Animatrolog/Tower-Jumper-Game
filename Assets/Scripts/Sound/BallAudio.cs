using UnityEngine;

[RequireComponent(typeof(ScoreManager))]
public class BallAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _meteorClip;
    [SerializeField] private MeteorMode _meteorMode;

    private BallJump _jump;
    private ScoreManager _combo;

    private void Awake()
    {
        _jump = GetComponent<BallJump>();
        _combo = GetComponent<ScoreManager>();
    }

    private void OnEnable()
    {
        _jump.OnJump += Jump;
        _meteorMode.OnMeteorMode += Meteor;
    }

    private void OnDisable()
    {
        _jump.OnJump -= Jump;
        _meteorMode.OnMeteorMode -= Meteor;
    }

    private void Jump()
    {
        _audioSource.pitch = Random.Range(1.2f, 2.0f);
        _audioSource.clip = _jumpClip;
        _audioSource.Play();
    }

    private void Meteor()
    {
        _audioSource.PlayOneShot(_meteorClip);
    }
}

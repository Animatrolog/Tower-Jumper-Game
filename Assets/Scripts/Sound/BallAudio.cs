using UnityEngine;

public class BallAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MeteorMode _meteorMode;
    [SerializeField] private BallJump _jump;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _meteorClip;

    private void Awake()
    {
        _jump = GetComponent<BallJump>();
    }

    private void OnEnable()
    {
        _jump.OnJump += PlayJump;
        _meteorMode.OnMeteorMode += PlayMeteor;
    }

    private void OnDisable()
    {
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
}

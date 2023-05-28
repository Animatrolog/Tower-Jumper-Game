using UnityEngine;
using UnityEngine.Audio; 

public class UiSoundManager : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioClip _openClip;
    [SerializeField] private AudioClip _closeClip;
    [SerializeField] private AudioClip _colorChangeClip;
    [SerializeField] private AudioClip _upgradeClip;
    [SerializeField] private AudioClip _comboClip;
    [SerializeField] private AudioClip _failClip;
    [SerializeField] private AudioClip _breakClip;
    [SerializeField] private AudioClip _finishClip;

    public static UiSoundManager Instance;


    private void OnEnable()
    {
        _scoreManager.OnCombo += PlayCombo;
    }

    private void OnDisable()
    {
        _scoreManager.OnCombo += PlayCombo;
    }

    private void Awake()
    {
        Instance = this;
    }
    
    public void EnableSound(bool state)
    {
        float volume = -80f;

        if (state)
            volume = 0f;

        _audioMixer.SetFloat("Volume", volume);
    }

    public void PlayToggle(bool state)
    {
        if (state) PlayOpen();
        else PlayClose();
    }

    public void PlayOpen()
    {
        _audioSource.pitch = 1f;
        _audioSource.clip = _openClip;
        _audioSource.Play();
    }

    public void PlayClose()
    {
        _audioSource.pitch = 1f;
        _audioSource.clip = _closeClip;
        _audioSource.Play();
    }

    public void PlayColorChange()
    {
        _audioSource.pitch = 1f;
        _audioSource.PlayOneShot(_colorChangeClip);
    }

    public void PlayUpgrade()
    {
        _audioSource.pitch = 1f;
        _audioSource.PlayOneShot(_upgradeClip);
    }

    private void PlayCombo(int combo)
    {
        _audioSource.pitch = 1f + (combo * 0.1f);
        _audioSource.PlayOneShot(_comboClip);
    }

    public void PlayFail()
    {
        _audioSource.pitch = 1f;
        _audioSource.PlayOneShot(_failClip);
    }

    public void PlayBreak()
    {
        _audioSource.pitch = 1f;
        _audioSource.PlayOneShot(_breakClip);
    }

    public void PlayFinish()
    {
        _audioSource.pitch = 1f;
        _audioSource.PlayOneShot(_finishClip);
    }
}

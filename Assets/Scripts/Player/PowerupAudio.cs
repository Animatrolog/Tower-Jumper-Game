using UnityEngine;

public class PowerupAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    public void PlayPowerupStart(Powerup powerup)
    {
        powerup.OnPowerupCanceled += PlayPowerupEnd;
        if(powerup.StartClip != null)
            _audioSource.PlayOneShot(powerup.StartClip);
    }

    private void PlayPowerupEnd(Powerup powerup)
    {
        powerup.OnPowerupCanceled -= PlayPowerupEnd;
        if (powerup.EndClip != null)
            _audioSource.PlayOneShot(powerup.EndClip);
    }
}

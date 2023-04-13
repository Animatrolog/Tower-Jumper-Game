using UnityEngine;

[RequireComponent(typeof(FloorPiece))]
public class GroundPieceAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _breakClip;
    [SerializeField] private AudioClip _shrinkClip;

    private FloorPiece _groundPiece;

    private void Awake()
    {
        _groundPiece = GetComponent<FloorPiece>();
    }

    private void OnEnable()
    {
        _groundPiece.OnPieceBreak += Break;
        _groundPiece.OnPieceShrink += Shrink;
    }

    private void OnDisable()
    {
        _groundPiece.OnPieceBreak -= Break;
        _groundPiece.OnPieceShrink -= Shrink;
    }

    private void Break()
    {
        _audioSource.enabled = true;
        _audioSource.pitch = Random.Range(1f, 1.3f);
        _audioSource.PlayOneShot(_breakClip);
    }

    private void Shrink()
    {
        
        //_audioSource.pitch = Random.Range(.8f, 1.2f);
        //_audioSource.PlayOneShot(_shrinkClip);
    }
}

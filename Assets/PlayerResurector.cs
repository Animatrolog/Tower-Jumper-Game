using UnityEngine;

public class PlayerResurector : MonoBehaviour
{
    [SerializeField] private GameMode _gameMode;
    [SerializeField] private FloorPiece _resurectionPiece;
    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private int _resurectionsCount = 1;
    [SerializeField] private GameObject _resurectButton;
    [SerializeField] private ParticleSystem _particles;

    public void PrepareResurection()
    {
        _resurectButton.SetActive(_resurectionsCount > 0);
        if(_resurectionsCount < 1)
            return;
    }

    public void ResurectPlayer()
    {
        ReplaceFloorPiece();
        TimeScaler.SetTimeScale(1f);
        _gameStateManager.SetState(GameState.Game);
        Instantiate(_particles, transform.position + (Vector3.up * .5f), Quaternion.identity, transform);
        _resurectionsCount--;
    }

    private void ReplaceFloorPiece()
    {
        FloorPiece lastPiece = _gameMode.CurrentPiece;
        FloorPiece piece = Instantiate(_resurectionPiece, lastPiece.transform.position, Quaternion.LookRotation(Vector3.Scale(transform.position, new(1, 0, 1))));
        _gameMode.TowerPieces[_gameMode.TowerPieces.IndexOf(lastPiece)] = piece;
        lastPiece.gameObject.SetActive(false);
    }
}

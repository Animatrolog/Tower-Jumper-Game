using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResurector : MonoBehaviour
{
    [SerializeField] private GameMode _gameMode;
    [SerializeField] private FloorPiece _resurectionPiece;
    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private int _resurectionsCount = 1;
    [SerializeField] private GameObject _resurectButton;
    [SerializeField] private ParticleSystem _particles;

    private FloorPiece _lastPiece;

    public void PrepareResurection(FloorPiece lastPiece)
    {
        _resurectButton.SetActive(_resurectionsCount > 0);
        if(_resurectionsCount < 1)
            return;
        _lastPiece = lastPiece;
    }

    public void ResurectPlayer()
    {
        ReplaceFloorPiece();
        Time.timeScale = 1f;
        _gameStateManager.SetState(GameState.Game);
        Instantiate(_particles, transform.position + (Vector3.up * .5f), Quaternion.identity, transform);
        _resurectionsCount--;
    }

    private void ReplaceFloorPiece()
    {
        FloorPiece piece = Instantiate(_resurectionPiece, _lastPiece.transform.position, Quaternion.LookRotation(Vector3.Scale(transform.position, new(1, 0, 1))));
        _gameMode.TowerPieces[_gameMode.TowerPieces.IndexOf(_lastPiece)] = piece;
        _lastPiece.gameObject.SetActive(false);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class GameMode : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private bool _cleanOldPieces;

    public List<FloorPiece> TowerPieces;
    public UnityAction OnFloorReached;
    public FloorPiece CurrentPiece { get; private set; }

    private void OnEnable()
    {
        _levelGenerator.OnLevelGenerationCompleate += StartGameMode;
    }

    private void OnDisable()
    {
        _levelGenerator.OnLevelGenerationCompleate -= StartGameMode;
    }

    private async void FloorCheck()
    {
        for ( int i = 0; i < TowerPieces.Count; i++)
        {
            CurrentPiece = TowerPieces[i];
            while(true)
            {
                if (!_ball || !TowerPieces[i]) return;
                
                if (_ball.transform.position.y < TowerPieces[i].transform.position.y - 0.2f)
                    break;
                await Task.Yield();
            }

            if (_cleanOldPieces) DestroyOldPiece(i);
            //_levelGenerator.SpawnRandomPiece(i + 10, i * 0.001f);
            TowerPieces[i].Shrink();
            OnFloorReached?.Invoke();
        }
    }

    private void DestroyOldPiece(int currentIndex)
    {
        if (currentIndex > 2)
            Destroy(TowerPieces[currentIndex - 3].gameObject);
    }

    private void StartGameMode()
    {
        TowerPieces = _levelGenerator.TowerPieces;
        FloorCheck();
    }
}

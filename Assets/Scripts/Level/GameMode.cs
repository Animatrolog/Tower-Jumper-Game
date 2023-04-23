using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class GameMode : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private bool _cleanOldPieces;
    [SerializeField] private int _levelLenght;
    [SerializeField] private bool _isInfiniteMode;

    private int _level;
    private GameDataManager _gameDataManager;

    public List<FloorPiece> TowerPieces;
    public UnityAction OnFloorReached;
    public FloorPiece CurrentPiece { get; private set; }

    public void NextLevel()
    {
        _level++;
        _gameDataManager.Level = _level;
    }

    private void Awake()
    {
        _gameDataManager = GameDataManager.Instance;
    }

    private void Start()
    {
        LoadLevelData();
        if (_isInfiniteMode)
        {
            _levelGenerator.GenerateLevel(_level, 10, true);
            StartGameMode();
            return;
        }
        _levelGenerator.GenerateLevel(_level, _levelLenght, false);
        StartGameMode();
    }

    private void LoadLevelData()
    {
        if (_gameDataManager != null)
            _level = _gameDataManager.Level;
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
            if (_isInfiniteMode) _levelGenerator.SpawnRandomPiece(i + 10, i * 0.002f);
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

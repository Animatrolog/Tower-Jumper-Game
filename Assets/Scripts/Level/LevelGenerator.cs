using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int _levelLenght;
    [SerializeField] private List<FloorPiece> _poolOfPrefabs;
    [SerializeField] private FloorPiece _firstPiece;
    [SerializeField] private GameObject _corePiece;
    [SerializeField] private Transform _finishPiece;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private BallMovement _ball;
    [SerializeField] private float _difficultyFactor = 0.001f;
    private int _level;
    private GameDataManager _gameDataManager;
    private int _previousIndex;

    public UnityAction OnLevelGenerationCompleate;
    public List<FloorPiece> TowerPieces { get; private set; }

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
        GenerateLevel();
    }

    private void LoadLevelData()
    {
        if (_gameDataManager != null)
            _level = _gameDataManager.Level;
    }

    private void GenerateLevel()
    {
        float deadlySliceProbability = _level * _difficultyFactor;
        TowerPieces = new List<FloorPiece>();
        Random.InitState(_level);

        for (int i = 0; i < _levelLenght; i++ )
        {
            if ( i == 0)
            {
                SpawnPiece(_firstPiece, i);
                continue;
            }
            SpawnRandomPiece(i, deadlySliceProbability);
        }
        Instantiate(_corePiece, _offset * _levelLenght, Quaternion.identity, transform);
        _finishPiece.transform.position = _offset * (_levelLenght + 0.5f);
        OnLevelGenerationCompleate?.Invoke();
    }

    private int _angle = 0;

    public void SpawnRandomPiece(int index, float deadlySliceProbability)
    {
        int prefabIndex = Random.Range(0, _poolOfPrefabs.Count);
        
        while (prefabIndex == _previousIndex)
            prefabIndex = Random.Range(0, _poolOfPrefabs.Count);

        _previousIndex = prefabIndex;
        var piece = SpawnPiece(_poolOfPrefabs[prefabIndex], index);

        piece.Initialize(deadlySliceProbability, deadlySliceProbability);
    }

    private FloorPiece SpawnPiece(FloorPiece piecePrefab, int index)
    {
        Instantiate(_corePiece, _offset * index, Quaternion.identity, transform);
        var piece = Instantiate(piecePrefab, _offset * index, Quaternion.Euler(0, _angle, 0), transform);
        TowerPieces.Add(piece);
        _angle += Random.Range(-45, 45);
        return piece;
    }

}

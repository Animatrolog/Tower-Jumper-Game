using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<FloorPiece> _poolOfPrefabs;
    [SerializeField] private FloorPiece _firstPiece;
    [SerializeField] private GameObject _corePiece;
    [SerializeField] private Transform _finishPiece;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private BallMovement _ball;
    [SerializeField] private float _difficultyAtStart = 0.2f;
    [SerializeField] private float _difficultyFactor = 0.01f;

    private int _previousIndex;

    public List<FloorPiece> TowerPieces { get; private set; }

    public void GenerateLevel(int randomSeed, int levelLength, bool infiniteMode)
    {
        Random.InitState(randomSeed);
        float deadlySliceProbability = randomSeed * _difficultyFactor;
        deadlySliceProbability += _difficultyAtStart;
        TowerPieces = new List<FloorPiece>();

        for (int i = 0; i < levelLength; i++ )
        {
            if ( i == 0)
            {
                SpawnPiece(_firstPiece, i);
                continue;
            }
            if(infiniteMode) deadlySliceProbability = i * 0.002f;
            SpawnRandomPiece(i, deadlySliceProbability);
        }

        if (infiniteMode)
        {
            _finishPiece.gameObject.SetActive(false);
            return;
        }
        _finishPiece.transform.position = _offset * (levelLength + 0.5f);
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

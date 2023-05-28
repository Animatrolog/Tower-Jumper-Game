using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameSaveData
{
    [SerializeField] private int _level = 1;
    [SerializeField] private int _skinID = 0;
    [SerializeField] private bool _isSoundEnabled = true;
    [SerializeField] private int _gameScore = 0;
    [SerializeField] private float _sensitivity = 2.5f;
    [SerializeField] private List<int> _unlockedSkins = new List<int> { 0 };
    [SerializeField] private int _nextSkinId = 0;
    [SerializeField] private float _nextSkinProgress = 0f;

    public int Level 
    { 
        get => _level; 
        set 
        {
            if (_level == value) return;
            _level = value; 
            OnDataChanged?.Invoke(); 
        } 
    }

    public int SkinID 
    { 
        get => _skinID;
        set 
        {
            if (_skinID == value) return;
            _skinID = value; 
            OnDataChanged?.Invoke(); 
        } 
    }

    public bool IsSoundEnabled 
    { 
        get => _isSoundEnabled; 
        set 
        { 
            if (_isSoundEnabled == value) return;
            _isSoundEnabled = value; 
            OnDataChanged?.Invoke(); 
        } 
    }

    public int GameScore 
    { 
        get => _gameScore; 
        set 
        { 
            if (_gameScore == value) return;
            _gameScore = value; 
            OnDataChanged?.Invoke();
        } 
    }

    public float Sensitivity 
    { 
        get => _sensitivity; 
        set 
        {
            if (_sensitivity == value) return; 
            _sensitivity = value; 
            OnDataChanged?.Invoke(); 
        } 
    }

    public List<int> UnlockedSkins
    {
        get => _unlockedSkins;
        set
        {
            if (_unlockedSkins == value) return;
            _unlockedSkins = value;
            OnDataChanged?.Invoke();
        }
    }

    public int NextSkinIndex 
    { 
        get => _nextSkinId; 
        set 
        { 
            if (_nextSkinId == value) return;
            _nextSkinId = value;
            OnDataChanged?.Invoke();
        } 
    }

    public float NextSkinProgress 
    { 
        get => _nextSkinProgress; 
        set 
        { 
            if (_nextSkinProgress == value) return;
            _nextSkinProgress = value;
            OnDataChanged?.Invoke();
        } 
    }

    [NonSerialized]
    public Action OnDataChanged;
}

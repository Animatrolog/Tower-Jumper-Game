using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkinUnlockAnimation : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private GameObject _getOrLosePanel;
    [SerializeField] private Button _nextButton;
    [SerializeField] private RawImage _fillImage;
    [SerializeField] private RawImage _bgImage;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private float _scoreModifier = 0.0001f;

    private GameDataManager _gameDataManager;
    private PlayerSkinManager _playerSkinManager;

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        _playerSkinManager = PlayerSkinManager.Instance;
        _fillImage.texture = _playerSkinManager.Skins[_gameDataManager.GameSaveData.NextSkinIndex].Icon;
        _bgImage.texture = _fillImage.texture;
        AnimateSslider();
    }

    public void AnimateSslider()
    {
        if (_gameDataManager.GameSaveData.UnlockedSkins.Count == _playerSkinManager.Skins.Count)
        {
            gameObject.SetActive(false);
            return;
        }

        _slider.value = _gameDataManager.GameSaveData.NextSkinProgress;
        float scoreToProgress = _scoreManager.Score * _scoreModifier;
        _gameDataManager.GameSaveData.NextSkinProgress += scoreToProgress;
        StartCoroutine(SliderAnimationCoroutine(scoreToProgress));
    }

    private IEnumerator SliderAnimationCoroutine(float scoreToProgress)
    {
        float progress = 0f;

        if(_gameDataManager.GameSaveData.NextSkinProgress >= 1)
        {
            _nextButton.gameObject.SetActive(false);
        }

        while(progress < 1f)
        {
            float tick = Time.deltaTime / _animationSpeed;
            progress += tick;
            _slider.value += tick * scoreToProgress;
            yield return null;
        }

        if (_gameDataManager.GameSaveData.NextSkinProgress >= 1)
        {
            _getOrLosePanel.SetActive(true);
        }
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinUnlockAnimation : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private GameObject _getOrLosePanel;
    [SerializeField] private Button _nextButton;
    [SerializeField] private RawImage _skinIcon;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private float _scoreModifier = 0.0001f;

    private GameDataManager _gameDataManager;
    private PlayerSkinManager _playerSkinManager;

    private void Start()
    {
        _gameDataManager = GameDataManager.Instance;
        _playerSkinManager = PlayerSkinManager.Instance;
        _skinIcon.texture = _playerSkinManager.Skins[_gameDataManager.GameSaveData.NextSkinIndex].Icon;
        AnimateSslider();
    }

    public void AnimateSslider()
    {
        if (_gameDataManager.GameSaveData.UnlockedSkins.Count == _playerSkinManager.Skins.Count)
        {
            gameObject.SetActive(false);
            return;
        }

        float prevProgress = _gameDataManager.GameSaveData.NextSkinProgress;
        _slider.value = _gameDataManager.GameSaveData.NextSkinProgress;
        float scoreToProgress = _scoreManager.Score * _scoreModifier;
        _gameDataManager.GameSaveData.NextSkinProgress = Mathf.Clamp01(prevProgress + scoreToProgress);
        _progressText.text = Mathf.Ceil(_gameDataManager.GameSaveData.NextSkinProgress * 100).ToString() + "%";
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

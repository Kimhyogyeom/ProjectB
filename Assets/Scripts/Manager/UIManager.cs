using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Gauge")]
    [SerializeField] private Slider _gaugeSlider;
    [SerializeField] private TextMeshProUGUI _gaugeText;
    [SerializeField] private TextMeshProUGUI _levelText;
    private int _currentLevel = 1;
    private float _currentGauge = 0f;
    private float _maxGauge = 150f;

    private float[] _initialMaxGauges = { 150f, 210f, 260f };

    public void AddGauge(float amount)
    {
        _currentGauge += amount;

        while (_currentGauge >= _maxGauge)
        {
            float overflow = _currentGauge - _maxGauge;
            LevelUp();
            _currentGauge = overflow;
        }

        if (_gaugeSlider != null)
        {
            _gaugeSlider.maxValue = _maxGauge;
            _gaugeSlider.value = _currentGauge;
        }

        if (_gaugeText != null)
        {
            _gaugeText.text = $"{_currentGauge}/{_maxGauge}";
        }
    }

    private void LevelUp()
    {
        _currentLevel++;
        _levelText.text = $"Lv.{_currentLevel}";
        if (_currentLevel <= _initialMaxGauges.Length)
        {
            _maxGauge = _initialMaxGauges[_currentLevel - 1];
        }
        else
        {
            _maxGauge += 40f;
        }
        // Level Up UI active
        GameManager.Instance._levelManager.ShowLevelUpUI();
    }
}

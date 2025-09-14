using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 게이지와 레벨 UI를 관리하는 매니저
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Gauge")]
    [SerializeField] private Slider _gaugeSlider;           // 경험치 게이지 슬라이더
    [SerializeField] private TextMeshProUGUI _gaugeText;    // 현재 게이지 텍스트
    [SerializeField] private TextMeshProUGUI _levelText;    // 레벨 텍스트

    private int _currentLevel = 1;      // 현재 레벨
    private float _currentGauge = 0f;   // 현재 게이지 값
    private float _maxGauge = 150f;     // 현재 최대 게이지

    private float[] _initialMaxGauges = { 150f, 210f, 260f };   // 초기 레벨별 최대 게이지 (Lv 1 ~ 3)

    /// <summary>
    /// 게이지 추가
    /// </summary>
    /// <param name="amount">추가할 게이지 값</param>
    public void AddGauge(float amount)
    {
        _currentGauge += amount;

        // 게이지가 최대치를 넘으면 레벨업 처리
        while (_currentGauge >= _maxGauge)
        {
            float overflow = _currentGauge - _maxGauge;
            LevelUp();
            _currentGauge = overflow;   // 남은 경험치로 다음 레벨 게이지 시작
        }

        // UI 업데이트
        if (_gaugeSlider != null)
        {
            _gaugeSlider.maxValue = _maxGauge;
            _gaugeSlider.value = _currentGauge;
        }

        if (_gaugeText != null)
        {
            _gaugeText.text = $"{Mathf.RoundToInt(_currentGauge)}/{Mathf.RoundToInt(_maxGauge)}";
        }
    }

    /// <summary>
    /// 레벨업 처리
    /// </summary>
    private void LevelUp()
    {
        _currentLevel++;
        _levelText.text = $"Lv.{_currentLevel}";

        // 초기 레벨에 맞는 최대 게이지 설정
        if (_currentLevel <= _initialMaxGauges.Length)
        {
            _maxGauge = _initialMaxGauges[_currentLevel - 1];
        }
        else
        {
            _maxGauge += 40f;   // 이후 레벨부터는 40씩 증가
        }

        // 레벨업 UI 표시
        GameManager.Instance._levelManager.ShowLevelUpUI();
    }
}

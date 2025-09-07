using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GroundGauge : MonoBehaviour
{
    [SerializeField] private Slider _slider;            // 점프 버튼 슬라이더
    [SerializeField] private float _recoverSpeed = 5f;  // 초당 채워지는 양

    /// <summary>
    /// 코루틴 실행
    /// </summary>
    private void Start()
    {
        StartCoroutine(FillRoutine());
    }

    private IEnumerator FillRoutine()
    {
        while (true)
        {
            // 게임 상태가 공격 중 이라면
            if (GameManager.Instance._gameState == GameManager.GameState.Attack)
            {
                // value가 maxValue(150) 보다 작다면 
                if (_slider.value < _slider.maxValue)
                {
                    // 초 당 상승
                    _slider.value += _recoverSpeed * Time.deltaTime;

                    // value가 maxValue(150) 보다 크다면 value = maxValue
                    if (_slider.value > _slider.maxValue)
                        _slider.value = _slider.maxValue;
                }
            }

            // 게임 상태 Ready
            yield return null;
        }
    }
}

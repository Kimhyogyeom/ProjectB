using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 그라운드와 Finish 그라운드 거리 비율 to 슬라이더
/// </summary>
public class DistanceSlider : MonoBehaviour
{
    [SerializeField] private Transform _groundObj;  // 그라운드
    [SerializeField] private Transform _finishObj;  // 피니쉬 그라운드
    [SerializeField] private Slider _gaugeSlider;   // 게이지 슬라이드

    private float startDistance;        // 초기 거리 (_groundObj, _finishObj)
    private bool _isReached = false;    // 1회 실행 위한 플래그

    /// <summary>
    /// _finishObj 오브젝트 활성화가 될 때 호출되는 거리 계산 함수
    /// </summary>
    public void DistanceCalculate()
    {
        // 시작할 때 두 오브젝트 사이의 거리 저장
        startDistance = Vector3.Distance(_groundObj.position, _finishObj.position);
    }

    /// <summary>
    /// InverseLerp : A와 B 사이에서 C의 선형 비율 계산 0~1
    /// </summary>
    void Update()
    {
        if (GameManager.Instance._gameState == GameManager.GameState.Stop) return;

        float currentDistance = Vector3.Distance(_groundObj.position, _finishObj.position);

        // 거리가 줄어들수록 1에 가까워짐
        float value = Mathf.InverseLerp(startDistance, 0f, currentDistance);

        _gaugeSlider.value = value;

        // 1회 실행
        if (value >= 0.99f && !_isReached)
        {
            _isReached = true;
            _gaugeSlider.value = 1f; // 확실히 1로 고정
            GameManager.Instance._gameState = GameManager.GameState.Stop;
            print("Finish");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 백그라운드 패턴 루프
/// </summary>
public class BackgroundPattern : MonoBehaviour
{
    [SerializeField] private RawImage _BgStar;              // 백그라운드 이미지(Star)
    [SerializeField] private float _scrollSpeedX = 0.2f;    // X 스크롤 스피드
    [SerializeField] private float _scrollSpeedY = 0.2f;    // Y 스크롤 스피드

    [Header("Scroll Check")]
    [SerializeField] private bool _scrollX = true;          // X축 스크롤 여부
    [SerializeField] private bool _scrollY = false;         // Y축 스크롤 여부

    void Update()
    {
        // uvRect 가져오기
        Rect rect = _BgStar.uvRect;

        // X 스크롤
        if (_scrollX)
            rect.x += _scrollSpeedX * Time.deltaTime;

        // Y 스크롤
        if (_scrollY)
            rect.y += _scrollSpeedY * Time.deltaTime;

        // 변경된 uvRect(rect) 적용
        _BgStar.uvRect = rect;
    }
}

using UnityEngine;

/// <summary>
/// 배경 Sprite(ea:3) 스크롤
/// </summary>
public class BackgroundLooper : MonoBehaviour
{
    [SerializeField] private float _backgroundSpeed = 1.0f; // 배경 스크롤 속도
    [SerializeField] private Transform[] _backgrounds;      // 반복할 배경들

    private int _startIndex = 0; // 현재 가장 위에 있는 배경 인덱스
    private int _endIndex = 2;   // 가장 마지막에 배치될 배경 인덱스

    private float _backgroundHeight = 9.99f; // 배경 이미지 높이

    /// <summary>
    /// 배경 무한 스크롤
    /// </summary>
    void Update()
    {
        // 배경 전체를 위로 이동
        transform.position += Vector3.up * _backgroundSpeed * Time.deltaTime;

        // 맨 위 배경이 카메라를 넘어가면 아래로 이동시킴
        if (_backgrounds[_startIndex].position.y > Camera.main.transform.position.y + 11f)
        {
            // 마지막 배경 아래로 위치시킴
            _backgrounds[_startIndex].localPosition = _backgrounds[_endIndex].localPosition + new Vector3(0f, -_backgroundHeight, 0f);

            // 인덱스 갱신
            _endIndex = _startIndex;
            _startIndex = (_startIndex + 1) % _backgrounds.Length;
        }
    }
}

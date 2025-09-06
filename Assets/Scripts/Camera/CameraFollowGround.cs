using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 그라운드 따라다니는 카메라
/// </summary>
public class CameraFollowGround : MonoBehaviour
{
    [SerializeField] private Transform _targetGround;   // 따라갈 타겟 바닥
    [SerializeField] private float _smoothTime = 0.3f;  // 카메라 이동 부드러운 시간

    private Vector3 _velocity = Vector3.zero;   // SmoothDamp용 속도 변수

    /// <summary>
    /// Follow Camera to ground
    /// </summary>
    void LateUpdate()
    {
        if (_targetGround == null) return;  // 타겟 없으면 종료

        // 카메라 목표 위치 계산 (타겟 Y 기준 - 오프셋)
        Vector3 targetPos = new Vector3(transform.position.x, _targetGround.position.y - 1.5f, transform.position.z);

        // 부드럽게 이동
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, _smoothTime);
    }
}

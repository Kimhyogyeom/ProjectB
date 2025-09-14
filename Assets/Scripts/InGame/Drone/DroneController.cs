using System.Collections;
using UnityEngine;

/// <summary>
/// 드론 레이저 컨트롤러
/// </summary>
public class DroneController : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private Transform _firePoint;              // 레이저 발사 기준 위치 (드론 자식 위치 등)
    [SerializeField] private float _maxLaserDistance = 20f;     // 레이저 최대 길이
    [SerializeField] private LayerMask _groundMask;             // 레이저 충돌 검사 대상 레이어
    [SerializeField] private string _targetTag = "BreakGround"; // 레이저 충돌 시 텍스트 호출할 태그
    [SerializeField] private int _laserDamage;                  // 레이저 데미지


    [Header("Laser Visuals")]
    [SerializeField] private LineRenderer _lineRenderer;        // 레이저 시각화를 위한 LineRenderer

    [Header("Timing Settings")]
    [SerializeField] private float _waitDuration = 2f;  // 레이저 발사 전 대기 시간
    [SerializeField] private float _fireDuration = 2f;  // 레이저 발사 시간
    [SerializeField] private float _hitInterval = 0.2f; // 레이저 충돌 시 텍스트 호출 주기(초 단위)
    private float _lastHitTime = 0f;                    // 마지막 호출 시간 기록

    void Awake()
    {
        // LineRenderer 초기 설정
        _lineRenderer.positionCount = 2;    // 시작/끝점 2개
        _lineRenderer.startWidth = 0.1f;    // 시작 지점 두께
        _lineRenderer.endWidth = 0.1f;      // 끝 지점 두께
    }

    void Start()
    {
        // 드론 생성 시 자동 발사 사이클 시작
        StartCoroutine(FireCycleRoutine());
    }

    /// <summary>
    /// 레이저 발사 사이클 코루틴
    /// - 무한 루프: 대기 → 발사 → 대기 → 발사 ...
    /// </summary>
    private IEnumerator FireCycleRoutine()
    {
        while (true)
        {
            // 대기 구간 : 레이저 꺼둠
            _lineRenderer.enabled = false;
            yield return new WaitForSeconds(_waitDuration);

            // 발사 구간 : 레이저 켜고 UpdateLaser()를 매 프레임 호출
            float elapsed = 0f;
            _lineRenderer.enabled = true;

            while (elapsed < _fireDuration)
            {
                UpdateLaser();              // 레이저 위치/충돌 업데이트
                elapsed += Time.deltaTime;  // 누적 시간
                yield return null;          // 다음 프레임까지 대기
            }
        }
    }

    /// <summary>
    /// 레이저 갱신 함수
    /// </summary>
    private void UpdateLaser()
    {
        Vector2 origin = _firePoint.position;
        Vector2 dir = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(origin, dir, _maxLaserDistance, _groundMask);
        Vector3 endPos;

        if (hit.collider != null)
        {
            endPos = hit.point;  // 충돌 위치

            // 태그 체크 후 일정 간격으로 데미지 적용 및 텍스트 표시
            if (hit.collider.CompareTag(_targetTag))
            {
                if (Time.time >= _lastHitTime + _hitInterval)
                {
                    _laserDamage = Random.Range(30, 51);
                    // 데미지 적용
                    hit.collider.GetComponent<BreakGroundController>()?.TakeDamage(_laserDamage);

                    // 데미지 텍스트 표시
                    DamageTextSpawner spawner = FindObjectOfType<DamageTextSpawner>();
                    spawner?.ShowDamage(_laserDamage, hit.point);

                    // 호출 시간 갱신
                    _lastHitTime = Time.time;
                }
            }
        }
        else
        {
            endPos = origin + dir * _maxLaserDistance;
        }

        // LineRenderer 갱신
        _lineRenderer.SetPosition(0, _firePoint.position);
        _lineRenderer.SetPosition(1, endPos);
    }

    /// <summary>
    /// 시각화
    /// </summary>
    void OnDrawGizmosSelected()
    {
        if (_firePoint)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_firePoint.position, _firePoint.position + Vector3.down * _maxLaserDistance);
        }
    }
}

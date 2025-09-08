using UnityEngine;

/// <summary>
/// 게이지에 Player UI 오브젝트
/// 부드럽게 회전시키는 컨트롤러
/// </summary>
public class SmoothRotateUI : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float _minAngle = 80f;     // 회전 최소 각도
    [SerializeField] private float _maxAngle = 100f;    // 회전 최대 각도
    [SerializeField] private float _angelSpeed = 15f;   // 회전 속도

    private float _currentAngle;    // 현재 회전 각도
    private int _direction = 1;     // 회전 방향 (1: 증가, -1: 감소)

    /// <summary>
    /// UI 오브젝트 회전
    /// </summary>
    void Update()
    {
        if (GameManager.Instance._gameState == GameManager.GameState.Stop) return;

        // 현재 각도를 방향과 속도에 따라 증가/감소
        _currentAngle += _direction * _angelSpeed * Time.deltaTime;

        // 최대/최소 각도 도달 시 방향 반전
        if (_currentAngle > _maxAngle)
        {
            _currentAngle = _maxAngle;
            _direction = -1;
        }
        else if (_currentAngle < _minAngle)
        {
            _currentAngle = _minAngle;
            _direction = 1;
        }

        // 실제 UI 회전 적용
        transform.localEulerAngles = new Vector3(0f, 0f, _currentAngle);
    }
}

using UnityEngine;

/// <summary>
/// 바닥 이동 컨트롤러
/// </summary>
public class GroundMoveDown : MonoBehaviour
{
    [Header("Settings")]
    public float _downSpeed = 100f;   // 바닥 이동 속도
    [SerializeField] private Transform _groundTr;       // 이동할 바닥 Transform

    /// <summary>
    /// 바닥 이동 (dir = Vector.Down)
    /// </summary>
    void Update()
    {
        if (GameManager.Instance._gameState == GameManager.GameState.Stop) return;

        // 바닥을 아래로 지속 이동
        _groundTr.position += Vector3.down * _downSpeed * Time.deltaTime;
    }
}

using UnityEngine;

/// <summary>
/// 파괴 될 그라운드 초기 생성
/// </summary>
public class BreakGroundGenerate : MonoBehaviour
{
    [SerializeField] private Collider2D _deathZone;         // 데스존
    [SerializeField] private GameObject _breakGroundPrefab; // 생성할 바닥 프리팹
    [SerializeField] private int _generateCount = 5;        // 생성할 바닥 개수
    [SerializeField] private float _ySpacing = 0.5f;        // 바닥 간 Y 간격

    [Header("Break Ground Color")]
    private Color color1 = new Color(1f, 1f, 1f);           // 흰색
    private Color color2 = new Color(1f, 0.733f, 0.506f);   // 오렌지 계열

    /// <summary>
    /// Break Ground 생성
    /// </summary>
    void Start()
    {
        for (int i = 0; i < _generateCount; i++)
        {
            // 각 바닥의 Y 위치 계산
            float yPos = -(_generateCount - 1 - i) * _ySpacing;
            Vector3 pos = transform.position + new Vector3(0, yPos, 0);

            // 바닥 생성
            GameObject breakGround = Instantiate(_breakGroundPrefab, pos, Quaternion.identity, transform);

            // 색상 및 좌우 반전 적용
            SpriteRenderer sr = breakGround.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = (i % 2 == 0) ? color1 : color2;  // 짝수/홀수 색상 구분
                sr.flipX = (i % 2 != 0);    // 홀수는 좌우 반전
            }
            Physics2D.IgnoreCollision(_deathZone, breakGround.GetComponent<Collider2D>());

        }
    }
}

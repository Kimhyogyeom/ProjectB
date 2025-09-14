using UnityEngine;

/// <summary>
/// 파괴 될 그라운드 초기 생성
/// </summary>
public class BreakGroundGenerate : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private DistanceSlider _distanceSlider;

    [SerializeField] private Collider2D _deathZone;         // 데스존
    [SerializeField] private GameObject _breakGroundPrefab; // 생성할 바닥 프리팹
    [SerializeField] private GameObject _breakGroundEnemyPrefab; // 생성할 바닥 프리팹
    [SerializeField] private int _generateCount = 5;        // 생성할 바닥 개수
    [SerializeField] private float _ySpacing = 0.5f;        // 바닥 간 Y 간격
    [SerializeField] private BoxCollider2D _deathZoneCollider2D;

    [Header("Break Ground Color")]
    private Color _colorWhite = new Color(1f, 1f, 1f);          // 흰색
    private Color _colorOrange = new Color(1f, 0.733f, 0.506f); // 오렌지 계열

    [Header("Other Object To Place")]
    [SerializeField] private GameObject _targetObj;             // 맨 아래에 위치시킬 오브젝트

    /// <summary>
    /// Break Ground 생성
    /// </summary>
    void Start()
    {
        GameObject firstGround = null; // 맨 처음 만든 그라운드 저장용

        for (int i = 0; i < _generateCount; i++)
        {
            if (i > 0 && i % 10 == 0)
            {
                float yPosition = -(_generateCount - 1 - i) * _ySpacing;
                Vector3 position = transform.position + new Vector3(0, yPosition, 0);

                GameObject breakGroundEnemyPrefab = Instantiate(_breakGroundEnemyPrefab, position, Quaternion.identity, transform);
                Physics2D.IgnoreCollision(_deathZoneCollider2D, breakGroundEnemyPrefab.GetComponent<Collider2D>());
                continue; // 일반 breakGround 생성 건너뛰기
            }

            // 각 바닥의 Y 위치 계산
            float yPos = -(_generateCount - 1 - i) * _ySpacing;
            Vector3 pos = transform.position + new Vector3(0, yPos, 0);

            // 바닥 생성
            GameObject breakGround = Instantiate(_breakGroundPrefab, pos, Quaternion.identity, transform);

            // 색상 및 좌우 반전 적용
            SpriteRenderer sr = breakGround.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = (i % 2 == 0) ? _colorWhite : _colorOrange;  // 짝수/홀수 색상 구분
                sr.flipX = (i % 2 != 0);    // 홀수는 좌우 반전
            }

            Physics2D.IgnoreCollision(_deathZone, breakGround.GetComponent<Collider2D>());

            // i == 0일 때(첫 번째 생성된 게 제일 아래)
            if (i == 0)
            {
                firstGround = breakGround;
            }
        }

        // 루프 끝난 뒤, 제일 아래(firstGround) 밑에 새 오브젝트 생성
        if (firstGround != null)
        {
            Vector3 belowPos = firstGround.transform.position + Vector3.down * _ySpacing;
            _targetObj.transform.position = belowPos;
            _targetObj.SetActive(true);

            // Ground, FinishGround : 초기 위치 세팅
            _distanceSlider.DistanceCalculate();
            // Instantiate(_targetObj, belowPos, Quaternion.identity, transform);
        }
    }

}

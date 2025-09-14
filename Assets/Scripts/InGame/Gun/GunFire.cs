using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 총 발사 컨트롤러
/// </summary>
public class GunFire : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;      // 생성할 총알 프리팹
    [SerializeField] private float _fireRate = 0.5f;        // 발사 간격 (초)
    [SerializeField] private Transform _fireStartPoint;     // 총알 발사 시작 위치

    [Header("Gun Sprites")]
    [SerializeField] private Sprite _spriteA;               // 기본 총 이미지
    [SerializeField] private Sprite _spriteB;               // 발사 애니메이션 이미지
    [SerializeField] private SpriteRenderer _gunRenderer;   // 총 스프라이트 렌더러

    [Header("Raycast Settings")]
    [SerializeField] private float _rayDistance = 10f;      // 레이캐스트 거리
    [SerializeField] private LayerMask _groundLayer;        // BreakGround 전용 레이어

    private float _fireTimer = 0f;  // 발사 타이머
    public List<GameObject> _bulletPool = new List<GameObject>();   // 총알 풀

    /// <summary>
    /// 오브젝트 활성화 시
    /// </summary>
    void OnEnable()
    {
        _fireTimer = 0; // 활성화될 때 타이머 초기화
    }

    /// <summary>
    /// 타이머 체크 & 총알 발사(생성)
    /// </summary>
    void Update()
    {
        if (GameManager.Instance._gameState == GameManager.GameState.Stop) return;

        _fireTimer += Time.deltaTime;   // 시간 누적

        if (_fireTimer >= _fireRate)
        {
            // Raycast
            RaycastHit2D hit = Physics2D.Raycast(_fireStartPoint.position, Vector2.down, _rayDistance, _groundLayer);

            if (hit.collider != null && hit.collider.CompareTag("BreakGround"))
            {
                GameManager.Instance._gameState = GameManager.GameState.Attack;
                // 총알 생성
                GenerateBullet();

            }
            else
            {
                GameManager.Instance._gameState = GameManager.GameState.Ready;
            }
            // hit == null & hit collider tag == BreakGround : Timer reset;
            _fireTimer = 0f;
        }
    }

    /// <summary>
    /// 총 발사 애니메이션, 총알(Pooling)
    /// </summary>
    void GenerateBullet()
    {
        // 총 발사 Sprite
        StartCoroutine(SwitchSprite());

        // 총 발사 
        SoundManager.Instance.PlaySFX(SoundManager.Instance._soundDatabase._playGunFire, 0.1f);

        // 총알 풀에서 비활성화된 총알을 찾아 재사용
        foreach (GameObject bullet in _bulletPool)
        {
            if (!bullet.activeSelf)
            {
                bullet.transform.position = _fireStartPoint.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);
                return;
            }
        }

        // 사용 가능한 총알이 없으면 새로 생성 후 풀에 추가
        GameObject newBullet = Instantiate(_bulletPrefab, _fireStartPoint.position, Quaternion.identity);
        _bulletPool.Add(newBullet);

    }

    /// <summary>
    /// 총알 애니메이션(Sprite Chage)
    /// </summary>    
    private IEnumerator SwitchSprite()
    {
        _gunRenderer.sprite = _spriteB; // 발사 이미지로 변경

        yield return new WaitForSeconds(0.1f);

        _gunRenderer.sprite = _spriteA; // 다시 기본 이미지로 복원
    }

    /// <summary>
    /// Scene 뷰에서 레이 확인 (에디터 전용)
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (_fireStartPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(_fireStartPoint.position, _fireStartPoint.position + Vector3.down * _rayDistance);
    }
}

using UnityEngine;

/// <summary>
/// 총알 동작 컨트롤러
/// </summary>
public class GunBullet : MonoBehaviour
{
    public float _bulletDamage = 50;                    // 총알 피해량
    [SerializeField] private float _bulletSpeed = 3f;   // 총알 이동 속도
    [SerializeField] private DamageTextSpawner _damageTextSpawner;  // 데미지 텍스트 스포너

    /// <summary>
    /// 총알 이동 (dir = Vector3.down)
    /// </summary>
    void Update()
    {
        // 매 프레임 아래 방향으로 이동
        transform.Translate(Vector2.down * _bulletSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 충돌 시
    /// </summary>
    /// <param name="collision">for GameObject Tag</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            // 사망 구역에 닿으면 비활성화
            this.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("BreakGround"))
        {
            // 부수는 지형에 닿으면 데미지 적용
            collision.GetComponent<BreakGroundController>()?.TakeDamage(_bulletDamage);

            // 데미지 텍스트 표시
            DamageTextSpawner spawner = FindObjectOfType<DamageTextSpawner>();
            spawner.ShowDamage(_bulletDamage, transform.position);

            // 총알 비활성화
            this.gameObject.SetActive(false);
        }
    }
}

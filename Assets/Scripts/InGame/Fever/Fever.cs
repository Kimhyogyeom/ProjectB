using UnityEngine;

public class Fever : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10f; // 레이 길이
    private int _feverDamage = 99999;

    void Update()
    {
        // 아래 방향으로 Ray
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance);

        // Scene 뷰에서 확인 (Play 모드에서만)
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);



        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("BreakGround"))
            {
                hit.collider.GetComponent<BreakGroundController>()?.TakeDamage(_feverDamage);

                // 데미지 텍스트 표시
                DamageTextSpawner spawner = FindObjectOfType<DamageTextSpawner>();
                spawner.ShowDamage(_feverDamage, transform.position);
            }
        }
    }

    // 에디터에서 항상 보이게 (Play 전에도 Scene 뷰에 표시됨)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}

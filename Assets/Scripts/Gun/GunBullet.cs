using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage = 50;
    [SerializeField] private float _bulletSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * _bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            this.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("BreakGround"))
        {
            collision.GetComponent<BreakGroundController>()?.TakeDamage(_bulletDamage);
            this.gameObject.SetActive(false);
            print("11");
        }
    }
}

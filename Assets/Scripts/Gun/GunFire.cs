using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private Transform _fireStartPoint;

    [Header("Gun Sprites")]
    [SerializeField] private Sprite _spriteA;
    [SerializeField] private Sprite _spriteB;
    [SerializeField] private SpriteRenderer _gunRenderer;

    private float _fireTimer = 0f;
    public List<GameObject> _bulletPool = new List<GameObject>();

    void OnEnable()
    {
        _fireTimer = 0;
    }
    void Update()
    {
        _fireTimer += Time.deltaTime;

        if (_fireTimer >= _fireRate)
        {
            GenerateBullet();
            _fireTimer = 0f;
        }
    }

    void GenerateBullet()
    {
        StartCoroutine(SwitchSprite());

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

        GameObject newBullet = Instantiate(_bulletPrefab, _fireStartPoint.position, Quaternion.identity);
        _bulletPool.Add(newBullet);
    }

    private IEnumerator SwitchSprite()
    {
        _gunRenderer.sprite = _spriteB;

        yield return new WaitForSeconds(0.1f);
        _gunRenderer.sprite = _spriteA;
    }
}

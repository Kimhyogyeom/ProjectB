using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private Transform _fireStartPoint;

    private float _fireTimer = 0f;
    [SerializeField] private List<GameObject> _bulletPool = new List<GameObject>();


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
        foreach (GameObject bullet in _bulletPool)
        {
            if (bullet.activeSelf == false)
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
}

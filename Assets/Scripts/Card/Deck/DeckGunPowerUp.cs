using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckGunPowerUp : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private GameObject[] _guns;
    [SerializeField] private float _damageIncrease = 1.4f;

    public void GunPowerUp(int level)
    {
        int count = Mathf.Min(level + 1, _guns.Length);

        for (int i = 0; i < count; i++)
        {

            List<GameObject> bullets = _guns[i].GetComponent<GunFire>()._bulletPool;
            foreach (var bullet in bullets)
            {
                bullet.GetComponent<GunBullet>()._bulletDamage *= _damageIncrease;
            }

        }
    }
}

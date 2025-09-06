using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckGunEaPlus : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private Transform _gunParentObject;
    [SerializeField] private Transform _gunGenPos;
    [SerializeField] private float _spacing = 0.2f;
    [SerializeField] private float _damageReduction = 0.8f;
    [SerializeField] private GameObject[] _guns;

    public void GunEaPlus(int level)
    {
        foreach (var gun in _guns)
        {
            gun.SetActive(false);
        }
        int count = Mathf.Min(level + 1, _guns.Length);

        float totalWidth = (count - 1) * _spacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < _guns.Length; i++)
        {
            if (i < count)
            {
                Vector3 offset = new Vector3(startX + i * _spacing, 0f, 0f);
                _guns[i].transform.position = _gunGenPos.position + offset;
                _guns[i].SetActive(true);

                // _guns[i].GetComponent<GunBullet>()._bulletDamage *= _damageReduction;
                List<GameObject> bullets = _guns[i].GetComponent<GunFire>()._bulletPool;
                foreach (var item in bullets)
                {
                    item.GetComponent<GunBullet>()._bulletDamage *= _damageReduction;

                }
            }
            else
            {
                _guns[i].SetActive(false);
            }
        }
    }
}

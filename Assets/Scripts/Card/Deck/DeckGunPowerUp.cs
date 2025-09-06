using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 덱 건 파워 업
/// </summary>
public class DeckGunPowerUp : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private GameObject[] _guns;            // 총 배열
    [SerializeField] private float _damageIncrease = 1.4f;  // 데미지 증가 배율

    /// <summary>
    /// 총 개수 / 레벨에 따라 데미지 증가
    /// </summary>
    /// <param name="level">카드 레벨</param>
    public void GunPowerUp(int level)
    {
        // 레벨 + 1 만큼 총 적용, 배열 길이 초과 방지
        int count = Mathf.Min(level + 1, _guns.Length);

        for (int i = 0; i < count; i++)
        {
            // 총의 총알 풀 가져오기
            List<GameObject> bullets = _guns[i].GetComponent<GunFire>()._bulletPool;
            foreach (var bullet in bullets)
            {
                // 총알 데미지 증가 적용
                bullet.GetComponent<GunBullet>()._bulletDamage *= _damageIncrease;
            }
        }
    }
}

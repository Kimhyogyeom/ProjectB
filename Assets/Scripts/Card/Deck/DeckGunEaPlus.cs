using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 덱 건 개수 업
/// </summary>
public class DeckGunEaPlus : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private Transform _gunParentObject;    // 총들을 담는 부모 오브젝트
    [SerializeField] private Transform _gunGenPos;          // 총 생성 기준 위치
    [SerializeField] private float _spacing = 0.2f;         // 총 사이 간격
    [SerializeField] private float _damageReduction = 0.8f; // 총 데미지 감소 비율
    [SerializeField] private GameObject[] _guns;            // 미리 만들어 놓은 총들

    /// <summary>
    /// 총 개수와 데미지를 레벨에 맞춰 설정
    /// </summary>
    /// <param name="level">카드 레벨</param>
    public void GunEaPlus(int level)
    {
        // 모든 총을 비활성화
        foreach (var gun in _guns)
        {
            gun.SetActive(false);
        }

        // 레벨 + 1 만큼 총을 활성화, 총 배열 길이 초과 방지
        int count = Mathf.Min(level + 1, _guns.Length);

        // 중앙 기준으로 좌우 균등 배치
        float totalWidth = (count - 1) * _spacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < _guns.Length; i++)
        {
            if (i < count)
            {
                // 위치 계산 및 적용
                Vector3 offset = new Vector3(startX + i * _spacing, 0f, 0f);
                _guns[i].transform.position = _gunGenPos.position + offset;
                _guns[i].SetActive(true);

                // 총알 데미지 감소 적용
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

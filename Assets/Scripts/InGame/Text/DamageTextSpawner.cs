using UnityEngine;
using TMPro;
using System;

/// <summary>
/// 데미지 텍스트를 생성하고, 화면에 표시하는 스폰 클래스
/// </summary>
public class DamageTextSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _damageTextPrefab;  // 데미지 텍스트 프리팹
    // [SerializeField] private Canvas _canvas;            // 텍스트를 표시할 캔버스
    [SerializeField] private Transform _parentObje;     // 데미지 텍스트 부모 오브젝트

    /// <summary>
    /// 데미지 표시
    /// </summary>
    /// <param name="damage">표시할 데미지 값</param>
    /// <param name="worldPosition">데미지를 입은 오브젝트의 월드 위치</param>
    public void ShowDamage(float damage, Vector3 worldPosition)
    {
        // 월드 위치를 화면 좌표로 변환
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);

        // 데미지 텍스트 프리팹 생성
        GameObject dmgTextObj = Instantiate(_damageTextPrefab, _parentObje);

        // 화면 좌표 위치로 이동
        dmgTextObj.transform.position = screenPos;

        // 텍스트 값 설정
        TextMeshProUGUI tmp = dmgTextObj.GetComponent<TextMeshProUGUI>();

        // 정수 문자열이 아니기에 Int.Parse 사용 x
        tmp.text = (Convert.ToInt32(damage)).ToString();

        // DamageText 스크립트 실행 (플레이)
        dmgTextObj.GetComponent<DamageText>().Play();
    }
}

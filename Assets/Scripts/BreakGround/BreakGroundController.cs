using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 파괴 될 그라운드 컨트롤러
/// </summary>
public class BreakGroundController : MonoBehaviour
{
    [SerializeField] private GameObject[] _coinObjects;             // 코인
    [SerializeField] private float _breakGroundHp = 1350;           // 바닥 HP   
    [SerializeField] private TextMeshProUGUI _breakGroundHpText;    // HP 텍스트 UI
    [SerializeField] private GameObject _boomObject;                // 파괴 시 나타나는 효과
    [SerializeField] private BoxCollider2D _breakGroundCollider;    // 바닥 Collider
    [SerializeField] private GameObject _breakGroundText;           // 바닥 텍스트
    [SerializeField] private SpriteRenderer _breakGroundSr;         // 바닥 스프라이트 렌더러
    private Vector3 _originalScale;                                 // 원래 크기 저장

    void Awake()
    {
        _originalScale = transform.localScale;  // 초기 스케일 저장
    }

    /// <summary>
    /// 데미지를 받는 함수
    /// </summary>
    public void TakeDamage(float damage)
    {
        _breakGroundHp -= damage;   // HP 감소
        _breakGroundHpText.text = _breakGroundHp.ToString();    // UI 갱신

        StopAllCoroutines();
        StartCoroutine(HitEffect());    // 히트 이펙트 실행

        if (_breakGroundHp <= 0)
        {
            GetBoomObject();    // HP 0이면 파괴 처리
        }
    }

    /// <summary>
    /// 바닥 히트 시 스케일 확대/축소 효과
    /// </summary>
    private IEnumerator HitEffect()
    {
        Vector3 targetScale = _originalScale * 1.1f;    // 살짝 확대
        float t = 0f;

        // 확대
        while (t < 0.1f)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, t / 0.1f);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // 원래 크기로 복귀
        t = 0f;
        while (t < 0.1f)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, t / 0.1f);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localScale = _originalScale;
    }

    /// <summary>
    /// 바닥 파괴 시 처리
    /// </summary>
    private void GetBoomObject()
    {
        _boomObject.SetActive(true);            // 파괴 이펙트 활성화
        _breakGroundCollider.enabled = false;   // Collider 해제
        _breakGroundText.SetActive(false);      // 텍스트 비활성화
        _breakGroundSr.enabled = false;         // 스프라이트 비활성화

        foreach (var coin in _coinObjects)
        {
            coin.SetActive(true);
        }

        StartCoroutine(BreakGroundDisable());   // 일정 시간 후 다시 활성화
    }

    /// <summary>
    /// 파괴 후 일정 시간 지나면 바닥 재활성화
    /// </summary>
    private IEnumerator BreakGroundDisable()
    {
        yield return new WaitForSeconds(1f);
        _boomObject.SetActive(false);           // 파괴 이펙트 비활성화
        _breakGroundCollider.enabled = true;    // Collider 활성화
        _breakGroundText.SetActive(true);       // 텍스트 활성화
        _breakGroundSr.enabled = true;          // 스프라이트 활성화
        gameObject.SetActive(false);            // 바닥 오브젝트 비활성화
    }
}

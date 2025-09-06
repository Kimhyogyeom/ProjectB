using System.Collections;
using UnityEngine;

/// <summary>
/// 광부 이동 및 채굴 동작을 관리하는 컨트롤러
/// </summary>
public class MinerController : MonoBehaviour
{
    [SerializeField] private byte _minerDirection;          // 0: 왼쪽 시작, 1: 오른쪽 시작
    [SerializeField] private Transform _startPosLeft;       // 왼쪽 시작 위치
    [SerializeField] private Transform _startPosRight;      // 오른쪽 시작 위치
    [SerializeField] private Transform _endPos;             // 이동 후 도착 위치
    [SerializeField] private float _minerMoveSpeed = 2f;    // 이동 속도

    [SerializeField] private SpriteRenderer _spriteRenderer;    // 광부 스프라이트 렌더러
    [SerializeField] private Animator _bodyAnim;                // 몸통 애니메이터
    [SerializeField] private Animator _minerAnim;               // 광부 애니메이터
    [SerializeField] private GameObject _minerAnimObj;          // 광부 애니메이션 오브젝트
    [SerializeField] private GameObject _starObj;               // 채굴 후 스타 오브젝트

    /// <summary>
    /// 코루틴 시작
    /// </summary>
    private void Start()
    {
        StartCoroutine(MiningLoop()); // 채굴 루프 시작
    }

    /// <summary>
    /// 광부 무한 채굴 루프
    /// </summary>
    private IEnumerator MiningLoop()
    {
        while (true)
        {
            // 시작 위치로 이동
            if (_minerDirection == 0)
            {
                _spriteRenderer.flipX = false;
                yield return StartCoroutine(MoveToLocalPosition(_startPosLeft.localPosition));
            }
            else if (_minerDirection == 1)
            {
                _spriteRenderer.flipX = true;
                yield return StartCoroutine(MoveToLocalPosition(_startPosRight.localPosition));
            }

            // 채굴 애니메이션 4회 재생
            for (int i = 0; i < 4; i++)
            {
                _bodyAnim.SetTrigger("Mine");
                _minerAnimObj.SetActive(true);
                _minerAnim.SetTrigger("Mine");

                yield return new WaitForSeconds(1f);
            }
            _minerAnimObj.SetActive(false);
            _starObj.SetActive(true);   // 채굴 완료 후 스타 표시

            // 도착 위치 이동 전 스프라이트 방향 변경
            if (_minerDirection == 0) _spriteRenderer.flipX = true;
            else if (_minerDirection == 1) _spriteRenderer.flipX = false;

            // 종료 위치로 이동
            yield return StartCoroutine(MoveToLocalPosition(_endPos.localPosition));

            // UI 게이지 증가
            GameManager.Instance._uiManager.AddGauge(40);

            // 이동 후 스프라이트 방향 원복
            if (_minerDirection == 0) _spriteRenderer.flipX = false;
            else if (_minerDirection == 1) _spriteRenderer.flipX = true;
        }
    }

    /// <summary>
    /// 지정된 로컬 위치까지 부드럽게 이동 > endPos : 스타 비활성화
    /// </summary>
    private IEnumerator MoveToLocalPosition(Vector3 targetLocalPos)
    {
        while (Vector3.Distance(transform.localPosition, targetLocalPos) > 0.01f)
        {
            Vector3 dir = (targetLocalPos - transform.localPosition).normalized;
            transform.localPosition += dir * _minerMoveSpeed * Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetLocalPos;

        if (_starObj.activeSelf)
            _starObj.SetActive(false);
    }
}

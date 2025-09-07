using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GroundJump : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private GroundHp _groundHp;        // 그라운드 Hp 관련 컴포넌트

    [Header("UI")]
    [SerializeField] private Button _jumpButton;        // 점프 버튼
    [SerializeField] private Slider _jumpSlider;        // 0 ~ 150 슬라이더
    [SerializeField] private Image _jumpButtonImg;      // 점프 버튼 이미지

    [SerializeField] private GameObject _hitImagObje;   // 히트될 때 켜질 오브젝트

    [Header("Settings Jump")]
    [SerializeField] private float _jumpHeight = 2f;    // 점프 높이 (현재 위치에서 상대)
    [SerializeField] private float _jumpSpeed = 5f;     // 이동 속도
    [SerializeField] private float _jumpCost = 50f;     // 점프 시 감소량

    private bool _isJumping = false;                    // 점프 중인지 판단
    private float _jumpTargetY;                         // 점프 Y축 값

    [Header("Settings Hit")]
    [SerializeField] private float _hitJumpHeight = 2f; // Hit 점프 높이 (현재 위치에서 상대)
    [SerializeField] private float _hitJumpSpeed = 5f;  // Hit 이동 속도
    private bool _isHiting = false;                     // 그라운드 to 파괴될 그라운드와 충돌
    private float _hitJumpTargetY;                      // 점프 Y축 값

    /// <summary>
    /// AddListener Setting
    /// </summary>
    void Awake()
    {
        _jumpButton.onClick.AddListener(OnClickJumpButton);
    }

    /// <summary>
    /// Y축 상승 로직
    /// </summary>
    void Update()
    {
        // 점프 판단 여부
        if (_isJumping)
        {
            // 점프
            transform.position += Vector3.up * _jumpSpeed * Time.deltaTime;

            // 해당 위치 가면 점프 종료
            if (transform.position.y >= _jumpTargetY)
            {
                // 점프 중 다시 끄기
                _isJumping = false;
                // 코루틴 실행
                StartCoroutine(SuccessJumpCorutine());
            }
        }
        // 히트 판단 여부
        if (_isHiting)
        {
            // 점프
            transform.position += Vector3.up * _hitJumpSpeed * Time.deltaTime;

            // 해당 위치 가면 점프 종료
            if (transform.position.y >= _hitJumpTargetY)
            {
                // Hit
                _groundHp.TakeDamage();
                // 히트 중 다시 끄기
                _isHiting = false;
                // 코루틴 실행
                StartCoroutine(GroundHitCorutine());
            }
        }
    }
    /// <summary>
    /// 점프에 성공 할 때 실행 될 코루틴
    /// </summary>    
    IEnumerator SuccessJumpCorutine()
    {
        // 1초 대기 : 연속 점프 방지
        yield return new WaitForSeconds(1f);

        // 슬라이더 값에 따라 버튼 상태 결정
        while (_jumpSlider.value < 50)
        {
            _jumpButtonImg.color = Color.red;
            _jumpButton.interactable = false;
            yield return null;
        }

        // 슬라이더가 50 이상이 되면 버튼 활성화
        _jumpButtonImg.color = Color.white;
        _jumpButton.interactable = true;
    }

    /// <summary>
    /// 히트 됐을때 실행할 코루틴
    /// </summary>    
    IEnumerator GroundHitCorutine()
    {
        _hitImagObje.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        _hitImagObje.SetActive(false);
    }

    /// <summary>
    /// 점프 버튼 클릭 시 호출 될 함수
    /// </summary>
    private void OnClickJumpButton()
    {
        // 슬라이더 잔량 체크
        if (!_isJumping && _jumpSlider.value >= _jumpCost)
        {
            _isJumping = true;
            _jumpTargetY = transform.position.y + _jumpHeight;

            _jumpButtonImg.color = Color.red;
            // 상호작용 끄기
            _jumpButton.interactable = false;
            // 점프 비용 차감
            _jumpSlider.value -= _jumpCost;
        }
    }

    /// <summary>
    /// 그라운드가 파괴될 그라운드 충돌 시 호출
    /// </summary>
    private void GroundToBreakGroundTrigger()
    {
        _isHiting = true;
        _hitJumpTargetY = transform.position.y + _hitJumpHeight;
    }

    /// <summary>
    /// 충돌 트리거 (Enter)
    /// </summary>    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BreakGround") && gameObject == this.gameObject)
        {
            GroundToBreakGroundTrigger();
        }
    }
}

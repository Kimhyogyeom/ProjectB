using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 카드 UI 컨트롤러
/// </summary>
public class CardUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button _cardButton;                // 카드 클릭 버튼
    [SerializeField] private TextMeshProUGUI _titleText;        // 카드 제목 텍스트
    [SerializeField] private TextMeshProUGUI _descriptionText;  // 카드 설명 텍스트
    [SerializeField] private TextMeshProUGUI _descriptionText2; // 카드 추가 설명 텍스트
    [SerializeField] private Image _iconImage;                  // 카드 아이콘
    [SerializeField] private Image star1;                       // 별 UI 1
    [SerializeField] private Image star2;                       // 별 UI 2
    [SerializeField] private Image star3;                       // 별 UI 3
    [SerializeField] private Animator cardAnim;                 // 카드 애니메이터
    private int _level = 0; // 카드 레벨
    private CardData _data; // 카드 데이터 참조

    /// <summary>
    /// AddListener Setting
    /// </summary>
    void Awake()
    {
        // 버튼 클릭 시 레벨 업 이벤트 등록
        _cardButton.onClick.AddListener(OnClickLevelUp);
        // 카드 타임 스케일에 영향 받지 않게
        cardAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    /// <summary>
    /// 카드 데이터와 레벨 설정
    /// </summary>
    public void SetCardData(CardData data, int level)
    {
        _data = data;
        _level = level;

        if (_titleText != null) _titleText.text = _data._title;
        if (_descriptionText != null) _descriptionText.text = _data._description;
        if (_descriptionText2 != null) _descriptionText2.text = _data._description2;
        if (_iconImage != null) _iconImage.sprite = _data._image;

        UpdateStarUI();
    }

    /// <summary>
    /// 카드 클릭 시 레벨 업 처리
    /// </summary>
    public void OnClickLevelUp()
    {
        StartCoroutine(CardClickCorutine());
    }
    /// <summary>
    /// 카드 클릭하면 실행될 코루틴
    /// </summary>
    IEnumerator CardClickCorutine()
    {
        cardAnim.SetTrigger("Click");
        yield return new WaitForSecondsRealtime(1.0f);

        // 카드 레벨업
        LevelUp();
        // 카드 레벨업 효과 적용
        ApplyEffect();
        // 카드 UI 정리 및 레벨업 UI 숨김
        transform.parent.GetComponent<SpawnRandomPrefabs>().ClearCards();
        GameManager.Instance._levelManager.HideLevelUpUI();
    }
    /// <summary>
    /// 카드 레벨 증가
    /// </summary>
    private void LevelUp()
    {
        _level++;

        GameManager.Instance._cardManager.SetLevel(_data._number, _level);

        UpdateStarUI();
    }

    /// <summary>
    /// Ster Sprite UI Update
    /// </summary>
    private void UpdateStarUI()
    {
        if (_data == null) return;

        if (_level == 0)
        {
            star1.sprite = _data._starLevelUp;
            star2.sprite = _data._starBasic;
            star3.sprite = _data._starBasic;
        }
        else if (_level == 1)
        {
            star1.sprite = _data._starLevelUp;
            star2.sprite = _data._starLevelUp;
            star3.sprite = _data._starBasic;
        }
        else if (_level == 2)
        {
            star1.sprite = _data._starLevelUp;
            star2.sprite = _data._starLevelUp;
            star3.sprite = _data._starLevelUp;
        }
    }

    /// <summary>
    /// 카드 효과 적용
    /// </summary>
    private void ApplyEffect()
    {
        if (_data == null) return;

        switch (_data._effectType)
        {
            case CardEffectType.GunPowerUp:
                GameManager.Instance._skillManager.GunPowerUp(_level);
                break;

            case CardEffectType.GunEaPlus:
                GameManager.Instance._skillManager.GunEaPlus(_level);
                break;

            case CardEffectType.MinerSpeed:
                GameManager.Instance._skillManager.MinerSpeed(_level);
                break;

            case CardEffectType.MinerProduction:
                GameManager.Instance._skillManager.MinerProduction(_level);
                break;

            case CardEffectType.DronePlus:
                GameManager.Instance._skillManager.DroneEaPlus(_level);
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 메모리 누수 방지: 파괴될 때 버튼 이벤트 해제
    /// </summary>
    private void OnDestroy()
    {
        if (_cardButton != null)
            _cardButton.onClick.RemoveListener(OnClickLevelUp);
    }
}

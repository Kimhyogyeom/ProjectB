using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Button _cardButton;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _descriptionText2;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Image star1;
    [SerializeField] private Image star2;
    [SerializeField] private Image star3;

    [SerializeField] private int _level = 0;

    private CardData _data;

    void Awake()
    {
        _cardButton.onClick.AddListener(OnClickLevelUp);
    }

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

    public void OnClickLevelUp()
    {
        LevelUp();

        ApplyEffect();

        transform.parent.GetComponent<SpawnRandomPrefabs>().ClearCards();
        GameManager.Instance._levelManager.HideLevelUpUI();
    }

    private void LevelUp()
    {
        _level++;
        if (_level > 2) _level = 2;

        GameManager.Instance._cardManager.SetLevel(_data._number, _level);

        UpdateStarUI();
    }

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
                break;

            case CardEffectType.MinerProduction:
                GameManager.Instance._skillManager.MinerProduction(_level);
                break;

            default:
                break;
        }
    }

    // 메모리 누수 방지 [파괴될 때]
    private void OnDestroy()
    {
        if (_cardButton != null)
            _cardButton.onClick.RemoveListener(OnClickLevelUp);
    }
}

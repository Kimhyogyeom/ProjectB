using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 세팅 버튼 컨트롤러
/// </summary>
public class SettignController : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject _settingObj;        // 세팅 UI 오브젝트

    [Header("Button")]
    [SerializeField] private Button _settingOpneButton;     // 세팅 Opne버튼
    [SerializeField] private Button _settingCloseButton;    // 세팅 Close버튼

    [Header("Bgm & Sfx & Vib")]
    [SerializeField] private Button _bgmToggleBtn;          // BGM 토글 버튼
    [SerializeField] private Button _sfxToggleBtn;          // SFX 토글 버튼
    [SerializeField] private Button _vibToggleBtn;          // VIB 토글 버튼

    [Header("Sprite & Text")]
    [SerializeField] private Sprite _toggleOnImg;
    [SerializeField] private Sprite _toggleOffImg;
    [SerializeField] private Image _bgmBtnImg;
    [SerializeField] private Image _sfxBtnImg;
    [SerializeField] private Image _vibBtnImg;
    [SerializeField] private TextMeshProUGUI _bgmToggleText;
    [SerializeField] private TextMeshProUGUI _sfxToggleText;
    [SerializeField] private TextMeshProUGUI _vibToggleText;

    [Header("Save & Cancle")]
    [SerializeField] private Button _settingSaveButton;     // SaveButton
    [SerializeField] private Button _settingCancleButton;   // CancleButton

    private bool _bgmBtnActive = true;
    private bool _sfxBtnActive = true;
    private bool _vibBtnActive = true;


    void Awake()
    {
        _settingOpneButton.onClick.AddListener(OpenSettingUI);
        _settingCloseButton.onClick.AddListener(CloseSettingUI);

        _bgmToggleBtn.onClick.AddListener(OnClickBgmButton);
        _sfxToggleBtn.onClick.AddListener(OnClickSfxButton);
        _vibToggleBtn.onClick.AddListener(OnClickVibButton);

        _settingSaveButton.onClick.AddListener(OnClickSaveButton);
        _settingCancleButton.onClick.AddListener(OnClickCancleButton);
    }
    /// <summary>
    /// 활성화 될 때
    /// </summary>
    void OnEnable()
    {
        StartCoroutine(SetButtonsCorutine());
    }

    private IEnumerator SetButtonsCorutine()
    {
        // Instance가 생성될 때까지 대기
        yield return new WaitUntil(() => PossessionManager.Instance != null);
        _bgmBtnActive = SoundManager.Instance._currentBgmBtnActive;
        _sfxBtnActive = SoundManager.Instance._currentSfxBtnActive;
        _vibBtnActive = SoundManager.Instance._currentVibBtnActive;
        ResetBtnState();
    }
    /// <summary>
    /// UI 활성화
    /// </summary>
    private void OpenSettingUI()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._soundDatabase._settingButtonClick);
        _settingObj.SetActive(true);
    }
    /// <summary>
    /// UI 비활성화
    /// </summary>
    private void CloseSettingUI()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._soundDatabase._settingButtonClick);
        _settingObj.SetActive(false);
    }
    /// <summary>
    /// 비지엠 버튼
    /// </summary>
    private void OnClickBgmButton()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._soundDatabase._settingButtonClick);
        SoundManager.Instance.BgmToggle();
        BgmBtnState();
    }
    /// <summary>
    /// 에스에프엑스 버튼
    /// </summary>
    private void OnClickSfxButton()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._soundDatabase._settingButtonClick);
        SoundManager.Instance.SfxToggle();
        SfxBtnState();

    }
    /// <summary>
    /// 진동 버튼
    /// </summary>
    private void OnClickVibButton()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._soundDatabase._settingButtonClick);
        SoundManager.Instance.VibToggle();
        VibBtnState();
    }
    /// <summary>
    /// 세이브 버튼
    /// </summary>
    private void OnClickSaveButton()
    {
        SoundManager.Instance.OnClickSavebutton();
        SoundManager.Instance._currentBgmBtnActive = _bgmBtnActive;
        SoundManager.Instance._currentSfxBtnActive = _sfxBtnActive;
        SoundManager.Instance._currentVibBtnActive = _vibBtnActive;
        CloseSettingUI();
    }
    /// <summary>
    /// 캔슬 버튼
    /// </summary>
    private void OnClickCancleButton()
    {
        SoundManager.Instance.OnClickCanclebutton();
        _bgmBtnActive = SoundManager.Instance._currentBgmBtnActive;
        _sfxBtnActive = SoundManager.Instance._currentSfxBtnActive;
        _vibBtnActive = SoundManager.Instance._currentVibBtnActive;

        ResetBtnState();
        CloseSettingUI();

    }

    private void BgmBtnState()
    {
        if (_bgmBtnActive)
        {
            _bgmBtnImg.sprite = _toggleOffImg;
            _bgmToggleText.text = "Off";
            _bgmBtnActive = false;
        }
        else
        {
            _bgmBtnImg.sprite = _toggleOnImg;
            _bgmToggleText.text = "On";
            _bgmBtnActive = true;
        }
    }
    private void SfxBtnState()
    {
        if (_sfxBtnActive)
        {
            _sfxBtnImg.sprite = _toggleOffImg;
            _sfxToggleText.text = "Off";
            _sfxBtnActive = false;
        }
        else
        {
            _sfxBtnImg.sprite = _toggleOnImg;
            _sfxToggleText.text = "On";
            _sfxBtnActive = true;
        }
    }
    private void VibBtnState()
    {
        if (_vibBtnActive)
        {
            _vibBtnImg.sprite = _toggleOffImg;
            _vibToggleText.text = "Off";
            _vibBtnActive = false;
        }
        else
        {
            _vibBtnImg.sprite = _toggleOnImg;
            _vibToggleText.text = "On";
            _vibBtnActive = true;
        }
    }
    private void ResetBtnState()
    {
        if (!SoundManager.Instance._currentBgmBtnActive)
        {
            _bgmBtnImg.sprite = _toggleOffImg;
            _bgmToggleText.text = "Off";
        }
        else
        {
            _bgmBtnImg.sprite = _toggleOnImg;
            _bgmToggleText.text = "On";
        }

        if (!SoundManager.Instance._currentSfxBtnActive)
        {
            _sfxBtnImg.sprite = _toggleOffImg;
            _sfxToggleText.text = "Off";
        }
        else
        {
            _sfxBtnImg.sprite = _toggleOnImg;
            _sfxToggleText.text = "On";
        }

        if (!SoundManager.Instance._currentVibBtnActive)
        {
            _vibBtnImg.sprite = _toggleOffImg;
            _vibToggleText.text = "Off";
        }
        else
        {
            _vibBtnImg.sprite = _toggleOnImg;
            _vibToggleText.text = "On";
        }
    }
}

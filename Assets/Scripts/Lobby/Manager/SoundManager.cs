using UnityEngine;

/// <summary>
/// 사운드 매니저
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource _bgmSource;
    public AudioSource _sfxSource;

    [Header("Database")]
    public SoundDatabase _soundDatabase;

    [Header("Setting value")]
    public bool _bgmCtrl = true;
    private bool _currentBgmCtrl = true;

    public bool _sfxCtrl = true;
    private bool _currentSfxCtrl = true;

    public bool _vibCtrl = true;
    private bool _currentVibCtrl = true;

    [Header("UI")]
    public bool _currentBgmBtnActive = true;
    public bool _currentSfxBtnActive = true;
    public bool _currentVibBtnActive = true;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// BGM 플레이
    /// </summary>  
    public void PlayBGM(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;

        if (_currentBgmCtrl)
            _bgmSource.PlayOneShot(clip, volume);
    }

    /// <summary>
    /// SFX 플레이
    /// </summary>    
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;

        if (_currentSfxCtrl)
            _sfxSource.PlayOneShot(clip, volume);
    }
    /// <summary>
    /// Vib 플레이
    /// </summary>
    public void PlayVib()
    {
        if (_currentVibCtrl)
        {
            Handheld.Vibrate();
        }
    }

    /// <summary>
    /// BGM 버튼 클릭
    /// </summary>
    public void BgmToggle() => _bgmCtrl = _bgmCtrl ? false : true;

    /// <summary>
    /// SFX 버튼 클릭
    /// </summary>
    public void SfxToggle() => _sfxCtrl = _sfxCtrl ? false : true;

    /// <summary>
    /// Vib 버튼 클릭
    /// </summary>
    public void VibToggle() => _vibCtrl = _vibCtrl ? false : true;

    /// <summary>
    /// 세이브 버튼 클릭
    /// </summary>
    public void OnClickSavebutton()
    {
        _currentBgmCtrl = _bgmCtrl;
        _currentSfxCtrl = _sfxCtrl;
        _currentVibCtrl = _vibCtrl;

        _bgmSource.mute = _currentBgmCtrl ? false : true;
        _sfxSource.mute = _currentSfxCtrl ? false : true;
    }

    /// <summary>
    /// 캔슬 버튼 클릭
    /// </summary>
    public void OnClickCanclebutton()
    {
        _bgmCtrl = _currentBgmCtrl;
        _sfxCtrl = _currentSfxCtrl;
        _vibCtrl = _currentVibCtrl;
    }
}
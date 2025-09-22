using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Image 쓰려면 필요

public class FeverButtonController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button _feverButton;
    [SerializeField] private Image _feverImage;

    [Header("Object")]
    [SerializeField] private GameObject _basicObject;
    [SerializeField] private GameObject _feverObject;

    [Header("Component")]
    [SerializeField] private GroundMoveDown _groundMoveDown;

    private bool _isCharging = true; // fillAmount 차오르는 중인지 여부
    private float _chargeSpeed = 0.05f;

    private AudioClip _feverClip;
    private AudioClip _playClip;

    void Awake()
    {
        _feverButton.onClick.AddListener(OnClickFeverButton);
    }
    void Start()
    {
        _feverClip = SoundManager.Instance._soundDatabase._feverBgm;
        _playClip = SoundManager.Instance._soundDatabase._playBgm;
    }

    void Update()
    {
        if (_isCharging && _feverImage.fillAmount < 1f)
        {
            _feverImage.fillAmount += _chargeSpeed * Time.deltaTime;
        }

        // 게이지가 가득 차면 버튼 활성화
        if (_feverImage.fillAmount >= 1f)
        {
            _feverButton.interactable = true;
        }
    }

    private void OnClickFeverButton()
    {
        StartCoroutine(FeverCoroutine());
    }

    IEnumerator FeverCoroutine()
    {
        SoundManager.Instance.PlayBGM(_feverClip, 0.5f);
        _feverImage.fillAmount = 0;
        _feverButton.interactable = false;
        _isCharging = false; // 충전 멈춤

        _groundMoveDown._downSpeed = 2;

        _basicObject.SetActive(false);
        _feverObject.SetActive(true);

        yield return new WaitForSeconds(11.0f);

        SoundManager.Instance.PlayBGM(_playClip);
        _groundMoveDown._downSpeed = 0.4f;

        _basicObject.SetActive(true);
        _feverObject.SetActive(false);

        // 다시 충전 시작
        _isCharging = true;
    }
}

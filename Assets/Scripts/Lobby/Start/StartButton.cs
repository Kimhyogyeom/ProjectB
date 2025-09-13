using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lobby to Play : Start Button
/// </summary>
public class StartButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _staminaText;

    [SerializeField] private Button _startButton;
    [SerializeField] private Animator _sliceAnimator;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _startButton.onClick.AddListener(OnClickStartButton);
    }
    private void OnClickStartButton()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance._soundDatabase._gameStartButtonClick);
        // 슬라이드 클로즈 : 오픈
        UITransition.Instance.CloseSlice();

        // 스테미너 감소
        StaminaManager.Instance.Decrease();

        // 코루틴 실행
        StartCoroutine(LobbyToGameCorutine());
    }
    IEnumerator LobbyToGameCorutine()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        UITransition.Instance.SetSliceOpen("Play");
    }
}

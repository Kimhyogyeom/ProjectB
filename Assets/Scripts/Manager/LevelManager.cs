using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 레벨 업 관련 UI 및 카드 스폰을 관리하는 매니저
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField] private SpawnRandomPrefabs spawnRandomPrefabs; // 카드 스폰 매니저
    [SerializeField] private Image _levelUpPopup;       // 레벨 업 팝업 UI
    [SerializeField] private Animator _animatorTitle;   // 레벨 업 타이틀 애니메이터

    /// <summary>
    /// 레벨 업 UI를 화면에 보여주는 함수
    /// </summary>
    public void ShowLevelUpUI()
    {
        if (_levelUpPopup != null)
            _levelUpPopup.gameObject.SetActive(true);   // 팝업 활성화

        if (_animatorTitle != null)
            _animatorTitle.updateMode = AnimatorUpdateMode.UnscaledTime;    // 애니메이션을 일시정지에도 동작하도록 설정

        if (spawnRandomPrefabs != null)
            spawnRandomPrefabs.StartCardSpawn();    // 카드 스폰 시작

        Time.timeScale = 0f;    // 게임 일시정지
    }

    /// <summary>
    /// 레벨 업 UI를 숨기고 게임 진행을 재개하는 함수
    /// </summary>
    public void HideLevelUpUI()
    {
        if (_levelUpPopup != null)
            _levelUpPopup.gameObject.SetActive(false);  // 팝업 비활성화

        Time.timeScale = 1f;    // 게임 시간 재개
    }
}

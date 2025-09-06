using UnityEngine;

/// <summary>
/// 게임 전반을 관리하는 싱글톤 GameManager
/// </summary>
public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static GameManager Instance = null;

    [Header("Managers")]
    public SkillManager _skillManager;  // 스킬 관련 관리
    public CardManager _cardManager;    // 카드 레벨 관리
    public UIManager _uiManager;        // UI 관리
    public LevelManager _levelManager;  // 레벨 관리

    /// <summary>
    /// 싱글톤 초기화
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // 이미 존재하면 중복 제거
            Destroy(this.gameObject);
        }
    }
}

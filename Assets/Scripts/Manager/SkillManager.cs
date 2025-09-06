using UnityEngine;

/// <summary>
/// 스킬 관련 기능을 관리하는 매니저
/// - Gun(총) 관련: 개수 증가, 파워 증가
/// - Miner(광부) 관련: 생산량 증가
/// </summary>
public class SkillManager : MonoBehaviour
{
    [Header("Gun")]
    [SerializeField] private DeckGunEaPlus _deckGunEaPlus;          // 총 개수 증가 처리
    [SerializeField] private DeckGunPowerUp _deckGunPowerUp;        // 총 데미지 증가 처리

    [Header("Miner")]
    [SerializeField] private DeckMinerProduction _deckMinerProduction;  // 광부 생산량 증가 처리

    /// <summary>
    /// 머신건 개수 증가
    /// </summary>
    /// <param name="level">카드 레벨</param>
    public void GunEaPlus(int level)
    {
        _deckGunEaPlus.GunEaPlus(level);
    }

    /// <summary>
    /// 머신건 데미지 증가
    /// </summary>
    /// <param name="level">카드 레벨</param>
    public void GunPowerUp(int level)
    {
        _deckGunPowerUp.GunPowerUp(level);
    }

    //──────────────────────────────────────────────────────────────────────

    /// <summary>
    /// 광부 생산량 증가
    /// </summary>
    /// <param name="level">카드 레벨</param>
    public void MinerProduction(int level)
    {
        _deckMinerProduction.MinerProduction(level);
    }
}

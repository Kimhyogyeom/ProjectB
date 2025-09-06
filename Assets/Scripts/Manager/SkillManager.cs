using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Gun")]
    [SerializeField] private DeckGunEaPlus _deckGunEaPlus;
    [SerializeField] private DeckGunPowerUp _deckGunPowerUp;
    [Header("Miner")]
    [SerializeField] private DeckMinerProduction _deckMinerProduction;

    /// <summary>
    /// 머신건 개수 +
    /// </summary>
    /// <param name="level"></param>
    public void GunEaPlus(int level)
    {
        _deckGunEaPlus.GunEaPlus(level);
    }
    /// <summary>
    /// 머신건 파워 +
    /// </summary>
    /// <param name="level"></param>
    public void GunPowerUp(int level)
    {
        _deckGunPowerUp.GunPowerUp(level);
    }

    //──────────────────────────────────────────────────────────────────────

    /// <summary>
    /// 광부 생산량 +
    /// </summary>
    /// <param name="level"></param>
    public void MinerProduction(int level)
    {
        _deckMinerProduction.MinerProduction(level);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 광부 생산량 업
/// </summary>
public class DeckMinerProduction : MonoBehaviour
{
    [SerializeField] private GameObject[] _miners;          // Miners
    [SerializeField] private float _productionValue = 0.1f; // 10%

    /// <summary>
    /// 생산량 업 / 레벨에 따라 생산량 증가
    /// </summary>
    /// <param name="level">카드 레벨</param>
    public void MinerProduction(int level)
    {
        foreach (var miner in _miners)
        {
            MinerController controller = miner.GetComponent<MinerController>();
            if (controller != null)
            {
                controller._minerProduction += controller._minerProduction * _productionValue * level;
            }
        }
    }
}

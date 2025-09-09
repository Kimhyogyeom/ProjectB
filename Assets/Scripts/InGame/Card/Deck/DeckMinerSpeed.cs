using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 광부 스피드 업
/// </summary>
public class DeckMinerSpeed : MonoBehaviour
{
    [SerializeField] private GameObject[] _miners;  // Miners
    [SerializeField] private float _speedIncreasePercent = 0.3f; // 30%

    /// <summary>
    /// 스피드 업 / 레벨에 따라 스피드 증가
    /// </summary>
    /// <param name="level">카드 레벨</param>
    public void MinerSpeed(int level)
    {
        foreach (var minerObj in _miners)
        {
            MinerController controller = minerObj.GetComponent<MinerController>();
            if (controller != null)
            {
                controller._minerMoveSpeed += controller._minerMoveSpeed * _speedIncreasePercent * level;
            }
        }
    }
}

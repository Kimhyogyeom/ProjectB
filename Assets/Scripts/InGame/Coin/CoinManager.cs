using System;
using TMPro;
using UnityEngine;

/// <summary>
/// 코인 매니저
/// </summary>
public class CoinManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _cointText;    // 코인 텍스트 (Game)

    private float _gainCoinValue = 2.0f;    // + 코인 Value

    public float _currentCoin = 0f;         // 현재 코인 값

    public void GetCoin()
    {
        _currentCoin += _gainCoinValue;
        _cointText.text = Convert.ToInt32(_currentCoin).ToString();
        PossessionManager.Instance._inGameCoin += _gainCoinValue;

        // PossessionManager.Instance._inGameCoin += _currentCoin;
        // print("xx");
        // print(PossessionManager.Instance._inGameCoin);
    }
}
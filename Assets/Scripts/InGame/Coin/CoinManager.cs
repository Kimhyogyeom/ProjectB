using System;
using TMPro;
using UnityEngine;

/// <summary>
/// 코인 매니저
/// </summary>
public class CoinManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _cointText;

    private float _gainCoinValue = 2.0f;

    public float _currentCoin = 0f;

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
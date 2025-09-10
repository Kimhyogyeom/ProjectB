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

    public void GetCoin()
    {
        float coin = PossessionManager.Instance._inGameCoin += _gainCoinValue;
        _cointText.text = Convert.ToInt32(coin).ToString();
    }
}
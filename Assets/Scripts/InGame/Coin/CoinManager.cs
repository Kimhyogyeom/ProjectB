using System;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cointText;

    private float _gainCoinValue = 2.0f;

    public void GetCoin()
    {
        float coin = GameManager.Instance._possessionManager._inGameCoin += _gainCoinValue;
        _cointText.text = Convert.ToInt32(coin).ToString();
    }
}
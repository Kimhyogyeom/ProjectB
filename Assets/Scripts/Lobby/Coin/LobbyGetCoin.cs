using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyGetCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    void OnEnable()
    {
        StartCoroutine(SetCoinTextWhenReady());
    }

    private IEnumerator SetCoinTextWhenReady()
    {
        // Instance가 생성될 때까지 대기
        yield return new WaitUntil(() => PossessionManager.Instance != null);

        if (_coinText != null)
            _coinText.text = PossessionManager.Instance._inGameCoin.ToString();
    }
}

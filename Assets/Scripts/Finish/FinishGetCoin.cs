using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 코인 가져오기
/// </summary>
public class FinishGetCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;  // 코인 표시할 UI Text
    [SerializeField] private float duration = 1.0f;     // 애니메이션 시간

    public void GetCoinRewardText()
    {
        float coin = GameManager.Instance._possessionManager._inGameCoin;
        StartCoroutine(GetCoinCorutine(coin));
    }

    /// <summary>
    /// 0 ~ targetCoin까지 duration시간 내 순차적 상승 연출
    /// </summary>
    /// <param name="targetCoin"></param>
    /// <returns></returns>
    IEnumerator GetCoinCorutine(float targetCoin)
    {
        float current = 0f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            // 0 ~ targetCoin까지 자연스럽게 증가
            current = Mathf.Lerp(0, targetCoin, elapsed / duration);
            coinText.text = Mathf.FloorToInt(current).ToString();
            yield return null;
        }

        // 마지막 보정
        coinText.text = targetCoin.ToString();
    }
}

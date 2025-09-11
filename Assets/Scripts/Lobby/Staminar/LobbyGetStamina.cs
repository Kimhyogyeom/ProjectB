using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyGetStamina : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _staminaText;
    void OnEnable()
    {
        StartCoroutine(SetStaminaTextWhenReady());
    }

    private IEnumerator SetStaminaTextWhenReady()
    {
        // Instance가 생성될 때까지 대기
        yield return new WaitUntil(() => PossessionManager.Instance != null);

        while (true)
        {
            _staminaText.text = StaminaManager.Instance._currentStamina.ToString();
            yield return null;
        }

    }
}

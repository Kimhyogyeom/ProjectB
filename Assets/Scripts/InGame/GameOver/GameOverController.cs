using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finishText;
    [SerializeField] private GameObject _finishObj;
    public void GameOver()
    {
        GameManager.Instance._gameState = GameManager.GameState.Stop;
        _finishText.text = "Game Over";
        _finishObj.SetActive(true);
    }
}

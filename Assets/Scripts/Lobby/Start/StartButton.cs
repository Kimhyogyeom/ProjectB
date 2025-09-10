using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lobby to Play : Start Button
/// </summary>
public class StartButton : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    [SerializeField] private Animator _sliceAnimator;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _startButton.onClick.AddListener(OnClickStartButton);
    }
    private void OnClickStartButton()
    {
        UITransition.Instance.CloseSlice();
        StartCoroutine(LobbyToGameCorutine());
    }
    IEnumerator LobbyToGameCorutine()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        UITransition.Instance.SetSliceOpen("Play");
    }
}

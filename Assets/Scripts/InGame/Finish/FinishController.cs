using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 끝났을 때 컨트롤러
/// </summary>
public class FinishController : MonoBehaviour
{
    [SerializeField] private Button _enterBtn;          // 확인 버튼
    [SerializeField] private GameObject _sliceObj;      // 슬라이드 UI
    [SerializeField] private GameObject _finishObj;     // reward UI

    [SerializeField] private Animator _finishDoorAnim;

    /// <summary>
    /// AddListener Setting
    /// </summary>
    void Awake()
    {
        _enterBtn.onClick.AddListener(OnClickEnterButton);
    }
    /// <summary>
    /// 게임 끝났을 때
    /// </summary>
    public void GameFinish()
    {
        _finishObj.SetActive(true);
    }
    /// <summary>
    /// 확인 버튼 눌렀을 때
    /// </summary>
    public void OnClickEnterButton()
    {
        // 버튼 클릭
        SoundManager.Instance.PlaySFX(SoundManager.Instance._soundDatabase._settingButtonClick);
        UITransition.Instance.CloseSlice();
        StartCoroutine(GameToLobbyCorutine());
    }
    IEnumerator GameToLobbyCorutine()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        UITransition.Instance.SetSliceOpen("Lobby");
    }
}

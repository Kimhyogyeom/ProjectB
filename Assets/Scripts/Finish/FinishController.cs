using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishController : MonoBehaviour
{
    [SerializeField] private Button _enterBtn;
    [SerializeField] private GameObject _sliceObj;
    [SerializeField] private GameObject _finishObj;

    void Awake()
    {
        _enterBtn.onClick.AddListener(OnClickEnterButton);
    }
    public void GameFinish()
    {
        _finishObj.SetActive(true);
    }

    public void OnClickEnterButton()
    {
        _sliceObj.SetActive(true);
    }
}

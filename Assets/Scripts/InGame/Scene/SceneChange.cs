using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 씬 체인지
/// </summary>
public class SceneChange : MonoBehaviour
{
    [Header("InGame")]
    [SerializeField] private GameObject _inGameElement;
    [SerializeField] private GameObject _inGameUI;
    private GameObject[] _inGameObjs;

    [Header("InLobby")]
    [SerializeField] private GameObject _inLobbyUI;
    private GameObject[] _inLobbyObjs;


    void Start()
    {
        _inGameObjs = new GameObject[] { _inGameElement, _inGameUI };
        _inLobbyObjs = new GameObject[] { _inLobbyUI };
    }
}

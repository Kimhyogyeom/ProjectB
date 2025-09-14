using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 드론 건 개수 업
/// </summary>
public class DeckDroneEaPlus : MonoBehaviour
{
    [SerializeField] private GameObject[] _droneObjs;

    public void DroneEaPlus(int level)
    {
        _droneObjs[level - 1].SetActive(true);
    }
}

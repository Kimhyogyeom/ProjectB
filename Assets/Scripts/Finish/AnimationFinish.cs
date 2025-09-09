using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFinish : MonoBehaviour
{
    [SerializeField] private GameObject _rewardObj;
    public void OnAnimationFinish()
    {
        _rewardObj.SetActive(true);
    }
}

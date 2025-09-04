using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowGround : MonoBehaviour
{
    [SerializeField] private Transform _targetGround;
    [SerializeField] private float _smoothTime = 0.3f;

    private Vector3 _velocity = Vector3.zero;

    void LateUpdate()
    {
        if (_targetGround == null) return;

        Vector3 targetPos = new Vector3(transform.position.x, _targetGround.position.y - 1.5f, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, _smoothTime);
    }
}

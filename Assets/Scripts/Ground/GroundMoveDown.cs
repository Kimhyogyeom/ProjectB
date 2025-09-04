using UnityEngine;

public class GroundMoveDown : MonoBehaviour
{
    [SerializeField] private float _downSpeed = 100f;
    [SerializeField] private Transform _groundTr;

    void Update()
    {
        _groundTr.position += Vector3.down * _downSpeed * Time.deltaTime;
    }

}

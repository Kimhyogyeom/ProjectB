using UnityEngine;

public class GroundMoveDown : MonoBehaviour
{
    [SerializeField] private float _downSpeed = 100f;
    [SerializeField] private RectTransform _groundRectTr;

    void Update()
    {
        _groundRectTr.anchoredPosition += Vector2.down * _downSpeed * Time.deltaTime;
    }

}

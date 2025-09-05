using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    [SerializeField] private float _backgroundSpeed = 1.0f;
    [SerializeField] private Transform[] _backgrounds;

    private int _startIndex = 0;
    private int _endIndex = 2;

    private float _backgroundHeight = 9.99f;

    void Update()
    {
        transform.position += Vector3.up * _backgroundSpeed * Time.deltaTime;

        if (_backgrounds[_startIndex].position.y > 11f)
        {
            _backgrounds[_startIndex].localPosition = _backgrounds[_endIndex].localPosition + new Vector3(0f, -_backgroundHeight, 0f);

            _endIndex = _startIndex;
            _startIndex = (_startIndex + 1) % _backgrounds.Length;
        }
    }
}

using UnityEngine;

public class SmoothRotateUI : MonoBehaviour
{
    [SerializeField] private float _minAngle = 80f;
    [SerializeField] private float _maxAngle = 100f;
    [SerializeField] private float _angelSpeed = 15f;

    private float _currentAngle;
    private int _direction = 1;

    void Update()
    {
        _currentAngle += _direction * _angelSpeed * Time.deltaTime;

        if (_currentAngle > _maxAngle)
        {
            _currentAngle = _maxAngle;
            _direction = -1;
        }
        else if (_currentAngle < _minAngle)
        {
            _currentAngle = _minAngle;
            _direction = 1;
        }

        transform.localEulerAngles = new Vector3(0f, 0f, _currentAngle);
    }
}

using UnityEngine;

public class BreakGroundGenerate : MonoBehaviour
{
    [SerializeField] private GameObject _breakGroundPrefab;
    [SerializeField] private int _generateCount = 5;
    [SerializeField] private float _ySpacing = 0.5f;

    void Start()
    {
        for (int i = 0; i < _generateCount; i++)
        {
            float yPos = -(i * _ySpacing);
            Vector3 pos = transform.position + new Vector3(0, yPos, 0);
            Instantiate(_breakGroundPrefab, pos, Quaternion.identity, transform);
        }
    }
}

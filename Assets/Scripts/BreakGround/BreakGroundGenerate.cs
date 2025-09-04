using UnityEngine;

public class BreakGroundGenerate : MonoBehaviour
{
    [SerializeField] private GameObject _breakGroundPrefab;
    [SerializeField] private int _generateCount = 5;
    [SerializeField] private float _ySpacing = 0.5f;

    private Color color1 = new Color(1f, 1f, 1f);
    private Color color2 = new Color(1f, 0.733f, 0.506f);

    void Start()
    {
        for (int i = 0; i < _generateCount; i++)
        {
            float yPos = -(_generateCount - 1 - i) * _ySpacing;
            Vector3 pos = transform.position + new Vector3(0, yPos, 0);

            GameObject breakGround = Instantiate(_breakGroundPrefab, pos, Quaternion.identity, transform);

            SpriteRenderer sr = breakGround.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = (i % 2 == 0) ? color1 : color2;

                sr.flipX = (i % 2 != 0);
            }
        }
    }
}

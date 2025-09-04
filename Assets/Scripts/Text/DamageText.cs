using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float _floatSpeedY = 50f;
    [SerializeField] private float _floatSpeedX = 20f;
    [SerializeField] private float _duration = 1f;

    [SerializeField] private TextMeshProUGUI _damageText;
    private float _timer;
    private float _randomXDir;

    public void Play()
    {
        _timer = 0f;
        _randomXDir = Random.Range(-_floatSpeedX, _floatSpeedX); // 랜덤 방향
        gameObject.SetActive(true);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        float progress = _timer / _duration;

        transform.position += new Vector3(_randomXDir, _floatSpeedY, 0) * Time.deltaTime;

        float alpha = Mathf.Lerp(1f, 0f, progress);
        _damageText.color = new Color(_damageText.color.r, _damageText.color.g, _damageText.color.b, alpha);

        if (_timer >= _duration)
        {
            Destroy(gameObject);
        }
    }
}

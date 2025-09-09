using UnityEngine;
using TMPro;

/// <summary>
/// 데미지 표시 텍스트를 띄우고, 위로 떠오르면서 사라지게 하는 클래스
/// </summary>
public class DamageText : MonoBehaviour
{
    [SerializeField] private float _floatSpeedY = 50f;      // Y축으로 떠오르는 속도
    [SerializeField] private float _floatSpeedX = 20f;      // X축으로 약간 흔들리며 떠오르는 속도
    [SerializeField] private float _duration = 1f;          // 텍스트 표시 지속 시간

    [SerializeField] private TextMeshProUGUI _damageText;   // 표시할 텍스트 컴포넌트

    private float _timer;   // 경과 시간
    private float _randomXDir;  // X축 랜덤 방향

    /// <summary>
    /// 데미지 텍스트 재생
    /// </summary>
    public void Play()
    {
        _timer = 0f;
        _randomXDir = Random.Range(-_floatSpeedX, _floatSpeedX);    // 랜덤 X 방향
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 텍스트 활성화 > 애니메이션 이동
    /// </summary>
    private void Update()
    {
        _timer += Time.deltaTime;
        float progress = _timer / _duration;

        // 텍스트 이동
        transform.position += new Vector3(_randomXDir, _floatSpeedY, 0) * Time.deltaTime;

        // 텍스트 투명도 점점 감소
        float alpha = Mathf.Lerp(1f, 0f, progress);
        _damageText.color = new Color(_damageText.color.r, _damageText.color.g, _damageText.color.b, alpha);

        // 지속 시간 경과 시 오브젝트 제거
        if (_timer >= _duration)
        {
            Destroy(gameObject);
        }
    }
}

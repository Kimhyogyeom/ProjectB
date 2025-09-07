using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _riseHeight = 1f;    // 위로 뜨는 높이
    [SerializeField] private float _duration = 0.5f;    // 올라가는 시간

    [SerializeField] private Transform _breakGround;    // 부모 오브젝트(파괴될 그라운드)
    private Vector3 _startPos;
    private Vector3 _targetPos;

    void OnEnable()
    {
        // 시작 위치
        _startPos = _breakGround.position + new Vector3(0f, -0.2f, 0f);

        // X축 랜덤
        float randomX = Random.Range(-0.5f, 0.5f);

        // 목표 위치 계산
        _targetPos = _startPos + new Vector3(randomX, _riseHeight, 0f);

        // 코루틴 실행
        StartCoroutine(PopCoroutine());
    }

    private IEnumerator PopCoroutine()
    {
        float timer = 0f;
        float ySpeed = Random.Range(1f, 2f); // y축 상승 속도 랜덤
        float xRandomPos = Random.Range(-0.5f, 0.5f);
        // 시작 위치 세팅
        transform.position = _startPos + new Vector3(xRandomPos, 0f, 0f);

        while (timer < _duration)
        {
            // 목표 y까지 이동
            transform.position += Vector3.up * ySpeed * Time.deltaTime;

            timer += Time.deltaTime;
            yield return null;
        }
        GameManager.Instance._coinManager.GetCoin();
        gameObject.SetActive(false);
    }
}

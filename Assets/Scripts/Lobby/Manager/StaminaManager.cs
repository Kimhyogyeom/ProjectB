using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// 스테미너 매니저
/// </summary>
public class StaminaManager : MonoBehaviour
{
    public static StaminaManager Instance;

    public int _currentStamina = 50;    // 현재 스테미나
    private int _maxStamina = 50;       // 최대 스테미나
    private int _decreaseAmount = 5;    // - 스테미나
    private int _increaseAmount = 5;    // + 스테미나
    [SerializeField] private float _recoveryInterval = 30f;    // 5분 = 300초

    private float _lastUpdateTime;      // 마지막으로 회복한 시간 계산

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // 시작 시점 시간 기록  : DateTime 앱 종료
        _lastUpdateTime = Time.time;
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Decrease();
        // }
        // 최대치라면 계산할 필요 x
        if (_currentStamina >= _maxStamina) return;

        // 마지막 업데이트 이후 시간 계산
        float elapsed = Time.time - _lastUpdateTime;

        // _recoveryInterval 지났다면
        if (elapsed >= _recoveryInterval)
        {
            // 경과한 시간 5분 단위 계산
            int recoverCount = Mathf.FloorToInt(elapsed / _recoveryInterval);

            // 스테미나 회복 / 최대치 : _maxStamina (50)
            _currentStamina = Mathf.Min(_currentStamina + recoverCount * _increaseAmount, _maxStamina);

            // 마지막 업데이트 시각 갱신
            _lastUpdateTime += recoverCount * _recoveryInterval;
        }
    }

    /// <summary>
    /// 스테미나 감소 호출 함수 (외부)
    /// </summary>
    public void Decrease()
    {
        _currentStamina -= _decreaseAmount;
    }
}

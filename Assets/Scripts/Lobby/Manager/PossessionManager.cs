using UnityEngine;

/// <summary>
/// InGame
/// 소지 요소
/// </summary>
public class PossessionManager : MonoBehaviour
{
    // 소지 코인
    public float _inGameCoin = 0;

    // 싱글톤 인스턴스
    public static PossessionManager Instance = null;

    /// <summary>
    /// 싱글톤 초기화
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // 이미 존재하면 중복 제거
            Destroy(this.gameObject);
        }
    }
}

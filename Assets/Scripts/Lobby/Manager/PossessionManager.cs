using TMPro;
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

    private void Awake()
    {
        // 싱글톤 처리 : 중복 오브젝트 삭제
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
    }
}

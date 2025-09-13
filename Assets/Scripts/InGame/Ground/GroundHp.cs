using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GroundHp : MonoBehaviour
{
    [SerializeField] private GameOverController _gameOverController;
    [Header("HP Settings")]
    [SerializeField] private Image[] _hpImages;             // 3개의 이미지
    [SerializeField] private GameObject[] _hpEffectImage;   // 3개의 파괴됐을 때 이미지
    [SerializeField] private Sprite _spriteA;   // 기본 HP
    [SerializeField] private Sprite _spriteB;   // 감소 Hp

    private int _currentHp = 3; // 총 HP

    /// <summary>
    /// HP 감소 함수
    /// </summary>
    public void TakeDamage()
    {
        if (_currentHp <= 0) return;

        _currentHp--; // HP 1 감소

        int damagedIndex = _currentHp; // 이번에 감소한 HP index

        // Hp가 0보다 같거나 클때
        if (damagedIndex >= 0)
        {
            // Sprite 변경
            // Boom Effect 활성화
            // 코루틴 실행
            _hpImages[damagedIndex].sprite = _spriteB;
            _hpEffectImage[damagedIndex].SetActive(true);
            StartCoroutine(HpBoomCorutine(_hpEffectImage[damagedIndex]));
        }

        if (_currentHp <= 0)
        {
            // Debug.Log("Die");
            // // 로직 작성 예정 Start / End 작업할 때 같이
            _gameOverController.GameOver();
        }
    }

    /// <summary>
    /// Hp 감소시 실행될 Boom Effect 코루틴
    /// </summary>
    IEnumerator HpBoomCorutine(GameObject boomIObject)
    {
        yield return new WaitForSeconds(1.0f);
        boomIObject.SetActive(false);
    }

    // // Test : Del
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         TakeDamage();
    //     }
    // }
}

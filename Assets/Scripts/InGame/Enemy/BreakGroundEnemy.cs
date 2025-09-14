using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BreakGroundEnemy : MonoBehaviour
{
    [SerializeField] private Image _background; // 투명 빨강 (고정)
    [SerializeField] private Image _fill;       // 진한 빨강 (차오름)
    [SerializeField] private float _fillDuration = 5f; // 차오르는 시간
    [SerializeField] private float _resetDelay = 2f;   // 공격 후 대기 시간

    [SerializeField] private Sprite _idleSprite;
    [SerializeField] private Sprite _attackSprite;
    [SerializeField] private SpriteRenderer _enemySpriteRenderer;
    [SerializeField] private BoxCollider2D _enemyBoxCollider2D;
    [SerializeField] private GameObject[] _activeObjects;

    public bool _isStart = false;

    public void StartCoroutine()
    {
        StartCoroutine(FillRoutine());
    }
    public void ObjectActive()
    {
        for (int i = 0; i < _activeObjects.Length; i++)
        {
            _activeObjects[i].SetActive(true);
        }
    }
    public void ObjectInActive()
    {
        for (int i = 0; i < _activeObjects.Length; i++)
        {
            _activeObjects[i].SetActive(false);
        }
    }

    private IEnumerator FillRoutine()
    {
        while (true)
        {
            float elapsed = 0f;
            while (elapsed < _fillDuration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / _fillDuration);
                _fill.fillAmount = t;
                yield return null;
            }

            _enemySpriteRenderer.sprite = _attackSprite;
            _enemyBoxCollider2D.enabled = true;
            // Debug.Log("공격!");

            // 대기
            yield return new WaitForSeconds(_resetDelay);

            // 초기화
            _fill.fillAmount = 0f;
            _enemySpriteRenderer.sprite = _idleSprite;
            _enemyBoxCollider2D.enabled = false;
        }
    }
}

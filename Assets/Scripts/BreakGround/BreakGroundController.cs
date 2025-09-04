using TMPro;
using UnityEngine;
using System.Collections;

public class BreakGroundController : MonoBehaviour
{
    [SerializeField] private int _breakGroundHp = 1350;
    [SerializeField] private TextMeshProUGUI _breakGroundHpText;

    private Vector3 _originalScale;

    void Awake()
    {
        _originalScale = transform.localScale;
    }

    public void TakeDamage(int damage)
    {
        _breakGroundHp -= damage;
        _breakGroundHpText.text = _breakGroundHp.ToString();

        StopAllCoroutines();
        StartCoroutine(HitEffect());

        if (_breakGroundHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator HitEffect()
    {
        Vector3 targetScale = _originalScale * 1.1f;
        float t = 0f;
        while (t < 0.1f)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, t / 0.1f);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        t = 0f;
        while (t < 0.1f)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, t / 0.1f);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localScale = _originalScale;
    }
}

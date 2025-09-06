using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreakGroundController : MonoBehaviour
{
    [SerializeField] private float _breakGroundHp = 1350;
    [SerializeField] private TextMeshProUGUI _breakGroundHpText;
    [SerializeField] private GameObject _boomObject;
    [SerializeField] private BoxCollider2D _breakGroundCollider;
    [SerializeField] private GameObject _breakGroundText;
    [SerializeField] private SpriteRenderer _breakGroundSr;
    private Vector3 _originalScale;

    void Awake()
    {
        _originalScale = transform.localScale;
    }

    public void TakeDamage(float damage)
    {
        _breakGroundHp -= damage;
        _breakGroundHpText.text = _breakGroundHp.ToString();

        StopAllCoroutines();
        StartCoroutine(HitEffect());

        if (_breakGroundHp <= 0)
        {
            GetBoomObject();
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

    private void GetBoomObject()
    {
        _boomObject.SetActive(true);
        _breakGroundCollider.enabled = false;
        _breakGroundText.SetActive(false);
        _breakGroundSr.enabled = false;
        StartCoroutine(BreakGroundDisable());
    }
    private IEnumerator BreakGroundDisable()
    {
        yield return new WaitForSeconds(1f);
        _boomObject.SetActive(false);
        _breakGroundCollider.enabled = true;
        _breakGroundText.SetActive(true);
        gameObject.SetActive(false);
        _breakGroundSr.enabled = true;
    }
}

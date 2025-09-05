using System.Collections;
using UnityEngine;

public class MinerController : MonoBehaviour
{
    [SerializeField] private byte _minerDirection;
    [SerializeField] private Transform _startPosLeft;
    [SerializeField] private Transform _startPosRight;
    [SerializeField] private Transform _endPos;
    [SerializeField] private float _minerMoveSpeed = 2f;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Animator _bodyAnim;
    [SerializeField] private Animator _minerAnim;
    [SerializeField] private GameObject _minerAnimObj;

    [SerializeField] private GameObject _starObj;

    private void Start()
    {
        StartCoroutine(MiningLoop());
    }

    private IEnumerator MiningLoop()
    {
        while (true)
        {
            if (_minerDirection == 0)
            {
                _spriteRenderer.flipX = false;
                yield return StartCoroutine(MoveToLocalPosition(_startPosLeft.localPosition));
            }
            else if (_minerDirection == 1)
            {
                _spriteRenderer.flipX = true;
                yield return StartCoroutine(MoveToLocalPosition(_startPosRight.localPosition));
            }

            for (int i = 0; i < 4; i++)
            {
                _bodyAnim.SetTrigger("Mine");
                _minerAnimObj.SetActive(true);
                _minerAnim.SetTrigger("Mine");

                yield return new WaitForSeconds(1f);

                _minerAnimObj.SetActive(false);
            }

            _starObj.SetActive(true);

            if (_minerDirection == 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_minerDirection == 1)
            {
                _spriteRenderer.flipX = false;
            }

            yield return StartCoroutine(MoveToLocalPosition(_endPos.localPosition));

            if (_minerDirection == 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_minerDirection == 1)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }
    private IEnumerator MoveToLocalPosition(Vector3 targetLocalPos)
    {
        while (Vector3.Distance(transform.localPosition, targetLocalPos) > 0.01f)
        {
            Vector3 dir = (targetLocalPos - transform.localPosition).normalized;
            transform.localPosition += dir * _minerMoveSpeed * Time.deltaTime;
            yield return null;
        }

        transform.localPosition = targetLocalPos;

        if (_starObj.activeSelf)
        {
            _starObj.SetActive(false);
        }
    }
}

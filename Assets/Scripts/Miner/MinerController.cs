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
                yield return StartCoroutine(MoveToPosition(_startPosLeft.position));
            }
            else if (_minerDirection == 1)
            {
                _spriteRenderer.flipX = true;
                yield return StartCoroutine(MoveToPosition(_startPosRight.position));
            }

            for (int i = 0; i < 4; i++)
            {
                _bodyAnim.SetTrigger("Mine");
                _minerAnimObj.SetActive(true);
                _minerAnim.SetTrigger("Mine");
                // _spriteRenderer.enabled = false;

                yield return new WaitForSeconds(1f);
                _minerAnimObj.SetActive(false);
                // _spriteRenderer.enabled = true;

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
            yield return StartCoroutine(MoveToPosition(_endPos.position));

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

    private IEnumerator MoveToPosition(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            Vector3 dir = (target - transform.position).normalized;
            transform.Translate(dir * _minerMoveSpeed * Time.deltaTime, Space.World);
            yield return null;
        }

        transform.position = target;
        if (_starObj.activeSelf == true)
        {
            _starObj.SetActive(false);
        }
    }
}

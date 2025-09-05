using System.Collections;
using UnityEngine;

public class MinerController : MonoBehaviour
{
    [SerializeField] private byte _minerDirection;
    [SerializeField] private Transform _startPosLeft;
    [SerializeField] private Transform _startPosRight;
    [SerializeField] private Transform _endPos;
    [SerializeField] private float _minerMoveSpeed = 2f;

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
                yield return StartCoroutine(MoveToPosition(_startPosLeft.position));
            }
            else if (_minerDirection == 1)
            {
                yield return StartCoroutine(MoveToPosition(_startPosRight.position));
            }


            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(1f);
            }

            yield return StartCoroutine(MoveToPosition(_endPos.position));
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
    }
}

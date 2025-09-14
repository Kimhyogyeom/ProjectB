using System.Collections;
using UnityEngine;

/// <summary>
/// 카드 프리팹을 랜덤하게 생성하고 관리하는 클래스
/// </summary>
public class SpawnRandomPrefabs : MonoBehaviour
{
    [Header("Prefab & Data")]
    [SerializeField] private GameObject _cardPrefab;    // 카드 프리팹
    [SerializeField] private CardData[] _cardDatas;     // 카드 데이터 배열
    [SerializeField] private int _spawnCount = 3;       // 한 번에 생성할 카드 개수
    [SerializeField] private float _spawnDelay = 0.5f;  // 카드 생성 간격(초)

    /// <summary>
    /// 카드 생성 시작
    /// </summary>
    public void StartCardSpawn()
    {
        StartCoroutine(CardSpawnCoroutine());
    }

    /// <summary>
    /// 카드 생성 코루틴
    /// </summary>
    private IEnumerator CardSpawnCoroutine()
    {
        // 프리팹이나 카드 데이터가 없으면 종료
        if (_cardPrefab == null || _cardDatas == null || _cardDatas.Length == 0)
            yield break;

        // 첫 카드 생성 전 대기
        yield return new WaitForSecondsRealtime(_spawnDelay);

        for (int i = 0; i < _spawnCount; i++)
        {
            // 카드 프리팹 생성
            GameObject cardObj = Instantiate(_cardPrefab, transform);

            // 애니메이터가 있다면 시간 스케일에 무관하게 업데이트
            Animator anim = cardObj.GetComponent<Animator>();
            if (anim != null)
                anim.updateMode = AnimatorUpdateMode.UnscaledTime;

            // 랜덤 카드 선택, 레벨 3이면 재선택
            CardData cardData;
            int currentLevel;
            do
            {
                int dataIndex = Random.Range(0, _cardDatas.Length);
                cardData = _cardDatas[dataIndex];
                currentLevel = GameManager.Instance._cardManager.GetLevel(cardData._number);
            }
            while (currentLevel >= 3);

            // CardUI 세팅
            CardUI cardUI = cardObj.GetComponent<CardUI>();
            if (cardUI != null)
                cardUI.SetCardData(cardData, currentLevel);

            // 다음 카드 생성 전 대기
            yield return new WaitForSecondsRealtime(_spawnDelay);
        }
    }

    /// <summary>
    /// 생성된 모든 카드 제거
    /// </summary>
    public void ClearCards()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}

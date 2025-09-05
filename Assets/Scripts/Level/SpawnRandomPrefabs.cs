using System.Collections;
using UnityEngine;

public class SpawnRandomPrefabs : MonoBehaviour
{
    [Header("Prefab & Data")]
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private CardData[] _cardDatas;
    [SerializeField] private int _spawnCount = 3;
    [SerializeField] private float _spawnDelay = 0.5f;

    public void StartCardSpawn()
    {
        StartCoroutine(CardSpawnCoroutine());
    }

    private IEnumerator CardSpawnCoroutine()
    {
        if (_cardPrefab == null || _cardDatas == null || _cardDatas.Length == 0)
            yield break;

        yield return new WaitForSecondsRealtime(_spawnDelay);

        for (int i = 0; i < _spawnCount; i++)
        {
            GameObject cardObj = Instantiate(_cardPrefab, transform);

            Animator anim = cardObj.GetComponent<Animator>();
            if (anim != null)
                anim.updateMode = AnimatorUpdateMode.UnscaledTime;

            int dataIndex = Random.Range(0, _cardDatas.Length);
            CardData cardData = _cardDatas[dataIndex];
            int currentLevel = GameManager.Instance._cardManager.GetLevel(cardData._number);

            CardUI cardUI = cardObj.GetComponent<CardUI>();
            if (cardUI != null)
                cardUI.SetCardData(cardData, currentLevel);

            yield return new WaitForSecondsRealtime(_spawnDelay);
        }
    }

    public void ClearCards()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}

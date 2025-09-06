using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카드별 레벨을 관리하는 클래스
/// </summary>
public class CardManager : MonoBehaviour
{
    /// <summary>
    /// Key : 카드 번호, Value : 레벨
    /// </summary>
    private Dictionary<int, int> _cardLevels = new Dictionary<int, int>();

    /// <summary>
    /// 특정 카드 번호의 레벨 가져오기 
    /// </summary>
    /// <param name="cardNumber">카드 번호</param>
    /// <returns></returns>
    public int GetLevel(int cardNumber)
    {
        if (_cardLevels.TryGetValue(cardNumber, out int level))
            return level;
        return 0; // 등록된 레벨이 없으면 0 반환
    }

    /// <summary>
    /// 특정 카드 번호의 레벨 설정 
    /// </summary>
    /// <param name="cardNumber">카드 번호</param>
    /// <param name="level">레벨</param>
    public void SetLevel(int cardNumber, int level)
    {
        _cardLevels[cardNumber] = level;
    }
}

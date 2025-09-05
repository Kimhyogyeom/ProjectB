using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private Dictionary<int, int> _cardLevels = new Dictionary<int, int>();

    public int GetLevel(int cardNumber)
    {
        if (_cardLevels.TryGetValue(cardNumber, out int level))
            return level;
        return 0;
    }

    public void SetLevel(int cardNumber, int level)
    {
        _cardLevels[cardNumber] = level;
    }
}

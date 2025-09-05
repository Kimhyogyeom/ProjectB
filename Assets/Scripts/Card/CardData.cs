using UnityEngine;

public enum CardEffectType
{
    None,               // None;
    GunPowerUp,         // 건 파워
    GunEaPlus,          // 건 개수 
    MinerSpeed,         // 광부 스피드
    MinerProduction,    // 광부 생산량
}

[CreateAssetMenu(fileName = "NewCardData", menuName = "Card/CardData")]
public class CardData : ScriptableObject
{
    public int _number;
    public string _title;
    public string _description;
    public string _description2;
    public Sprite _image;

    public int _level = 0;
    public Sprite _starBasic;
    public Sprite _starLevelUp;

    public CardEffectType _effectType = CardEffectType.None;
}

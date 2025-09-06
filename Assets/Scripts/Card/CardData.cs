using UnityEngine;

public enum CardEffectType
{
    None,               // None;
    GunPowerUp,         // 건 파워
    GunEaPlus,          // 건 개수 
    MinerSpeed,         // 광부 스피드
    MinerProduction,    // 광부 생산량
}
/// <summary>
/// 카드 ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "NewCardData", menuName = "Card/CardData")]
public class CardData : ScriptableObject
{
    public int _number;             // 카드 번호
    public string _title;           // 카드 제목
    public string _description;     // 카드 설명
    public string _description2;    // 추가 설명
    public Sprite _image;           // 카드 이미지

    public int _level = 0;          // 카드 레벨
    public Sprite _starBasic;       // 기본 별 이미지
    public Sprite _starLevelUp;     // 레벨 업 시 별 이미지

    public CardEffectType _effectType = CardEffectType.None;  // 카드 효과 타입
}

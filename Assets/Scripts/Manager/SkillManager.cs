using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private DeckGunEaPlus _deckGunEaPlus;

    public void GunEaPlus(int level)
    {
        _deckGunEaPlus.GunEaPlus(level);
    }
}

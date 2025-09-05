using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [Header("Managers")]
    public SkillManager _skillManager;
    public CardManager _cardManager;
    public UIManager _uiManager;
    public LevelManager _levelManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

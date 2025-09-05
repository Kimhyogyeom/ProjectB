using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SpawnRandomPrefabs spawnRandomPrefabs;
    [SerializeField] private Image _levelUpPopup;
    [SerializeField] private Animator _animatorTitle;

    public void ShowLevelUpUI()
    {
        if (_levelUpPopup != null)
            _levelUpPopup.gameObject.SetActive(true);

        if (_animatorTitle != null)
            _animatorTitle.updateMode = AnimatorUpdateMode.UnscaledTime;

        if (spawnRandomPrefabs != null)
            spawnRandomPrefabs.StartCardSpawn();

        Time.timeScale = 0f;
    }

    public void HideLevelUpUI()
    {
        if (_levelUpPopup != null)
            _levelUpPopup.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }
}

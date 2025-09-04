using TMPro;
using UnityEngine;

public class BreakGroundController : MonoBehaviour
{
    [SerializeField] private int _breakGroundHp = 1350;

    [SerializeField] TextMeshProUGUI _breakGroundHpText;
    public void TakeDamage(int damage)
    {
        _breakGroundHpText.gameObject.SetActive(true);
        _breakGroundHp -= damage;
        _breakGroundHpText.text = _breakGroundHp.ToString();

        if (_breakGroundHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

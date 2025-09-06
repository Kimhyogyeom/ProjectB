using UnityEngine;
using TMPro;

public class DamageTextSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _damageTextPrefab;
    [SerializeField] private Canvas _canvas;

    public void ShowDamage(float damage, Vector3 worldPosition)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);

        GameObject dmgTextObj = Instantiate(_damageTextPrefab, _canvas.transform);

        dmgTextObj.transform.position = screenPos;

        TextMeshProUGUI tmp = dmgTextObj.GetComponent<TextMeshProUGUI>();
        tmp.text = damage.ToString();

        dmgTextObj.GetComponent<DamageText>().Play();
    }
}

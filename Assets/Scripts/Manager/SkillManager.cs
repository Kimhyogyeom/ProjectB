using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] private Transform _gunParentObject;
    [SerializeField] private Transform _gunGenPos;
    [SerializeField] private float _spacing = 0.2f;
    [SerializeField] private GameObject[] _guns;

    public void GunEaPlus(int level)
    {
        foreach (var gun in _guns)
        {
            print(gun.gameObject.name);
            gun.SetActive(false);
        }
        int count = Mathf.Min(level + 1, _guns.Length);

        float totalWidth = (count - 1) * _spacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < _guns.Length; i++)
        {
            if (i < count)
            {
                _guns[i].SetActive(true);
                Vector3 offset = new Vector3(startX + i * _spacing, 0f, 0f);
                _guns[i].transform.position = _gunGenPos.position + offset;
            }
            else
            {
                _guns[i].SetActive(false);
            }
        }
    }
}

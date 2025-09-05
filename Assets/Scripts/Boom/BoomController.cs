// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BoomController : MonoBehaviour
// {
//     [SerializeField] private float _disableTime = 0.2f;
//     void OnEnable()
//     {
//         StartCoroutine(DisableObject());
//     }

//     IEnumerator DisableObject()
//     {
//         yield return new WaitForSeconds(_disableTime);
//         this.gameObject.SetActive(false);
//     }
// }

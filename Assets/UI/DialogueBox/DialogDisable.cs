using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class DialogDisable : MonoBehaviour
    {
        [SerializeField] private GameObject dialogBox;

        private void OnEnable()
        {
            StartCoroutine(HideDialogBox());
        }

        IEnumerator HideDialogBox()
        {
            yield return new WaitForSeconds(3f);
            dialogBox.SetActive(false);
        }
    }
}

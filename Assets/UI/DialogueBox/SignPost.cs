using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace WarriorOrigins
{
    public class SignPost : MonoBehaviour
    {
        public GameObject dialogBox;
        public TMP_Text dialogText;
        public string dialog;

        public void OpenDialogBox()
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
}

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

        public bool isInRange;
        public KeyCode interactKey;
        public KeyCode mouseInteractKey;

        private void Update()
        {
            if (!isInRange)
            {
                return;
            }

            if (isInRange)
            {
                if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(mouseInteractKey))
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                return;
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                
                GameManager.Instance.NotifyPlayer();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = false;
                dialogBox.SetActive(false);
                GameManager.Instance.DenotifyPlayer();
            }
        }
    }
}

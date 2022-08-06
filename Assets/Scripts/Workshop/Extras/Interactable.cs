using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WarriorOrigins
{
    public class Interactable : MonoBehaviour
    {
        public bool isInRange;
        public KeyCode interactKey;
        public KeyCode mouseInteractKey;
        public UnityEvent interactAction;


        private void Update()
        {
            if (isInRange)
            {
                if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(mouseInteractKey))
                {
                    EffectsManager.Instance.Play("PauseMenu");
                    interactAction.Invoke();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
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
                GameManager.Instance.DenotifyPlayer();
            }
        }
    }
}

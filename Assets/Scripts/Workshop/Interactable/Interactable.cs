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
        public UnityEvent interactAction;
        public GameObject dialogBox;

        private void Update()
        {
            if (isInRange)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    interactAction.Invoke();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                Debug.Log(collision + "is in range");
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            try
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    isInRange = false;
                    Debug.Log(collision + "is not in range");
                    dialogBox.SetActive(false);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }
    }
}

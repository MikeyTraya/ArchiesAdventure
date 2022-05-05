using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class PlayerTeleporter : MonoBehaviour
    {
        private GameObject currentTeleporter;

        public PlayerMovement player;

        public Animator transition;

        public float transitionTime;

        public static bool isMoving;

        private void Start()
        {
            player = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
            {
                if (currentTeleporter != null)
                {
                    StartCoroutine(LoadNextFloor());
                }
            }
        }

        IEnumerator LoadNextFloor()
        {
            player.canMove = false;
            transition.SetBool("Start", true);
            yield return new WaitForSeconds(transitionTime);
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            yield return new WaitForSeconds(transitionTime);
            transition.SetBool("Start", false);
            player.canMove = true;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Teleporter"))
            {
                currentTeleporter = collision.gameObject;
                GameManager.Instance.NotifyPlayer();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Teleporter"))
            {
                currentTeleporter = null;
                GameManager.Instance.DenotifyPlayer();
            }
        }
    }
}

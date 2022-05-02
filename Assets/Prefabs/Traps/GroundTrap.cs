using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class GroundTrap : MonoBehaviour
    {
        public float activationDelay;
        public float activeTime;

        public int damage = 1;
        public Animator animator;
        bool triggered;
        bool active;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("EnemyProjectiles"))
            {
                return;
            }

            if (!triggered)
            {
                StartCoroutine(ActivateGroundTrap());
                active = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            active = false;
        }

        private IEnumerator ActivateGroundTrap()
        {
            while (active)
            {
                triggered = true;
                yield return new WaitForSeconds(activationDelay);
                animator.SetBool("isSomethingHere", true);
                if (GameManager.Instance.health != 1)
                {
                    GameManager.Instance.TakeDamage(damage);
                }

                yield return new WaitForSeconds(activeTime);
                triggered = false;
                animator.SetBool("isSomethingHere", false);
            }
            
        }
    }
}

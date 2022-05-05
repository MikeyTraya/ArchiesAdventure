using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class GroundTrap : MonoBehaviour
    {
        public enum State
        {
            MainGame,
            Tutorial,
        }

        public State state;

        public float activationDelay;
        public float activeTime;

        public int damage = 1;
        public Animator animator;
        public bool triggered;
        public bool active;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("EnemyProjectiles") || collision.gameObject.CompareTag("Bombs"))
            {
                return;
            }

            if (!triggered)
            {
                StartCoroutine(ActivateGroundTrap(collision));
                active = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            active = false;
        }

        private IEnumerator ActivateGroundTrap(Collider2D collision)
        {
            while (active)
            {
                triggered = true;
                yield return new WaitForSeconds(activationDelay);
                animator.SetBool("isSomethingHere", true);

                switch (state)
                {
                    case State.MainGame:
                        if (collision.gameObject.CompareTag("Player"))
                        {
                            GameManager.Instance.TakeDamage(damage);
                        }

                        if (collision.gameObject.CompareTag("Enemy"))
                        {
                            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                        }

                        if (collision.gameObject.CompareTag("EnemyStationary"))
                        {
                            collision.gameObject.GetComponent<EnemyHealthStationary>().TakeDamage(damage);
                        }

                        if (collision.gameObject.CompareTag("EnemyProjectiles"))
                        {
                            break;
                        }
                        break;
                    case State.Tutorial:
                        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.health != 1)
                        {
                            GameManager.Instance.TakeDamage(damage);
                        }

                        if (collision.gameObject.CompareTag("Enemy"))
                        {
                            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                        }

                        if (collision.gameObject.CompareTag("EnemyStationary"))
                        {
                            collision.gameObject.GetComponent<EnemyHealthStationary>().TakeDamage(damage);
                        }

                        if (collision.gameObject.CompareTag("EnemyProjectiles"))
                        {
                            break;
                        }
                        break;
                    default:
                        break;
                }

                yield return new WaitForSeconds(activeTime);
                triggered = false;
                animator.SetBool("isSomethingHere", false);
            }
        }
    }
}

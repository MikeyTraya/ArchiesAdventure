using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class MeleeAttack : MonoBehaviour
    {
        public Animator animator;

        public float attackCooldown = 6f;
        private float actCooldown;

        public int damage;

        bool attacking = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }
        void Update()
        {
            if (actCooldown <= 0 && StaminaBar.Instance.currentStamina > 15)
            {
                if (Input.GetButton("Fire1"))
                {
                    StaminaBar.Instance.UseStamina(15);
                    attacking = true;
                    actCooldown = attackCooldown;
                    animator.SetTrigger("isAttacking");
                }
                else
                {
                    attacking = false;
                }
            }
            else
            {
                actCooldown -= Time.deltaTime;
            }
            
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (attacking)
            {
                if (collision == null)
                {
                    return;
                }

                if (collision.gameObject.CompareTag("Enemy"))
                {
                    collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                }

                if (collision.gameObject.CompareTag("EnemyStationary"))
                {
                    collision.gameObject.GetComponent<EnemyHealthStationary>().TakeDamage(damage);
                }

            }
        }
    }
}

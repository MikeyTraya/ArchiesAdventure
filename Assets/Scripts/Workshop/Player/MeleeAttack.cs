using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class MeleeAttack : MonoBehaviour
    {
        public Animator animator;
        private PlayerMovement playerMovement;

        public float attackCooldown = 6f;
        private float actCooldown;

        public int damage;

        public int staminaCost = 15;

        bool attacking = false;

        void Start()
        {
            animator = GetComponent<Animator>();
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }
        void Update()
        {
            if (!playerMovement.canMove)
            {
                return;
            }

            damage = GameManager.Instance.meleeDamage;
            staminaCost = GameManager.Instance.meleeWeaponStaminaCost;

            if (!PauseMenu.isPause)
            {
                if (actCooldown <= 0 && StaminaBar.Instance.currentStamina > staminaCost)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        StaminaBar.Instance.UseStamina(staminaCost);
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

                if (collision.gameObject.CompareTag("EnemyProjectiles"))
                {
                    return;
                }
            }
        }
    }
}

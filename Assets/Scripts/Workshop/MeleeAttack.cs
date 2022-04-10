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
        public float attackRange;

        public int damage;

        public Transform attackPosition;

        public LayerMask whatIsEnemies;

        void Start()
        {
            animator = GetComponent<Animator>();
        }
        void Update()
        {
            if (actCooldown <= 0)
            {
                if (Input.GetButton("Fire1"))
                {
                    Attack();
                }
            }
            else
            {
                actCooldown -= Time.deltaTime;
            }
            
        }

        void Attack()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
            
            actCooldown = attackCooldown;
            animator.SetTrigger("isAttacking");
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPosition.position, attackRange);
        }
    }
}

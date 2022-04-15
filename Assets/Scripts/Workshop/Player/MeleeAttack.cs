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

        bool attacking = false;

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
                    //Attack();
                    attacking = true;
                    actCooldown = attackCooldown;
                    animator.SetTrigger("isAttacking");
                }
            }
            else
            {
                actCooldown -= Time.deltaTime;
            }
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (attacking)
            {
                if (collision.transform.GetComponent<Transform>().CompareTag("Enemy"))
                {
                    collision.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPosition.position, attackRange);
        }
    }
}

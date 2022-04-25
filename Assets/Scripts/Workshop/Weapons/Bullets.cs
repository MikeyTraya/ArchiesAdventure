using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class Bullets : MonoBehaviour
    {
        public GameObject hitEffect;

        private GameObject effect;

        public int damage;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Physics2D.IgnoreCollision(player.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();

            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, .3f);
                Destroy(gameObject);
                return;
            }
            if (collision.gameObject.CompareTag("EnemyStationary"))
            {
                collision.gameObject.GetComponent<EnemyHealthStationary>().TakeDamage(damage);
                effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, .3f);
                Destroy(gameObject);
                return;
            }
            
            if (collision.gameObject.CompareTag("Walls"))
            {
                effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, .3f);
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("Breakables"))
            {
                effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, .3f);
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("Traps"))
            {
                effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, .3f);
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("EnemyProjectiles"))
            {
                effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, .3f);
                Destroy(gameObject);
            }
        }
    }
}

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

        void OnCollisionEnter2D(Collision2D collision)
        {

            effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, .3f);
            Destroy(gameObject);

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<Transform>().CompareTag("Enemy"))
            {
                collision.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, .3f);
                Destroy(gameObject);
                return;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyShroomBullets : MonoBehaviour
    {
        public enum State
        {
            MainGame,
            Tutorial,
        }

        public State state;

        public GameObject hitEffect;
        public int damage;

        private void Start()
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("EnemyStationary");
            Physics2D.IgnoreCollision(enemy.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyStationary"))
            {
                return;
            }

            if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Walls"))
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.3f);
                Destroy(gameObject);
                return;
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                switch (state)
                {
                    case State.MainGame:
                        GameManager.Instance.TakeDamage(damage);
                        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                        Destroy(effect, 0.3f);
                        Destroy(gameObject);
                        break;
                    case State.Tutorial:
                        if (GameManager.Instance.health != 1)
                        {
                            GameManager.Instance.TakeDamage(damage);
                            GameObject effectT = Instantiate(hitEffect, transform.position, Quaternion.identity);
                            Destroy(effectT, 0.3f);
                            Destroy(gameObject);
                        }
                        break;
                    default:
                        break;
                }
                
            }

            
        }
    }
}

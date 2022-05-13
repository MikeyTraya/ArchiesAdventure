using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyBullets : MonoBehaviour
    {
        public GameObject hitEffect;

        Vector3 targetPosition;

        public int damage;

        public float speed;

        private void Start()
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            Physics2D.IgnoreCollision(enemy.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            targetPosition = new Vector2(LevelGenerator.Instance.player.transform.position.x,
                LevelGenerator.Instance.player.transform.position.y - .8f);
        }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.3f);
                Destroy(gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.TakeDamage(damage);
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.3f);
                Destroy(gameObject);
                return;
            }

            if (collision.gameObject.CompareTag("Sword"))
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.3f);
                Destroy(gameObject);
                return;
            }
        }
    }
}

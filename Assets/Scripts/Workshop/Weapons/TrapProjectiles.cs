using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class TrapProjectiles : MonoBehaviour
    {
        public int damage;
        public float speed;
        public float resetTime;
        public float lifeTime;

        public GameObject sfx;
        private GameObject effects;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.TakeDamage(damage);
                effects = Instantiate(sfx, transform.position, Quaternion.identity);
                Destroy(effects, .3f);
                gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("Bullet"))
            {
                effects = Instantiate(sfx, transform.position, Quaternion.identity);
                Destroy(effects, .3f);
                gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("Sword"))
            {
                effects = Instantiate(sfx, transform.position, Quaternion.identity);
                Destroy(effects, .3f);
                gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("Walls"))
            {
                effects = Instantiate(sfx, transform.position, Quaternion.identity);
                Destroy(effects, .3f);
                gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("Breakables"))
            {
                effects = Instantiate(sfx, transform.position, Quaternion.identity);
                Destroy(effects, .3f);
                gameObject.SetActive(false);
            }

            if (collision.gameObject.CompareTag("Traps"))
            {
                effects = Instantiate(sfx, transform.position, Quaternion.identity);
                Destroy(effects, .3f);
                gameObject.SetActive(false);
            }


        }

        public void ActivateTrap()
        {
            effects = Instantiate(sfx, transform.position, Quaternion.identity);
            Destroy(effects, .3f);
            lifeTime = 0;
            gameObject.SetActive(true);
        }

        private void Update()
        {
            float movementSpeed = speed * Time.deltaTime;
            transform.Translate(movementSpeed, 0, 0);

            lifeTime += Time.deltaTime;
            if (lifeTime > resetTime)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

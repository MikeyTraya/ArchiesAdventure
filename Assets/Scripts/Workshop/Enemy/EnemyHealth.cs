using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyHealth : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;
     
        private bool flashActive;
        [SerializeField]
        private float flashLength = 0f;
        private float flashCounter = 0f;
        private SpriteRenderer enemySprite;

        private void Start()
        {
            enemySprite = GetComponent<SpriteRenderer>();
            currentHealth = maxHealth;
        }

        private void Update()
        {
            if (flashActive)
            {
                if (flashCounter > flashLength * .99f)
                {
                    enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
                }
                else if (flashCounter > flashLength * .82f)
                {
                    enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                }
                else if (flashCounter > flashLength * .66f)
                {
                    enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
                }
                else if (flashCounter > flashLength * .49f)
                {
                    enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                }
                else if (flashCounter > flashLength * .33f)
                {
                    enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
                }
                else if (flashCounter > flashLength * .16f)
                {
                    enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                }
                else if (flashCounter > 0)
                {
                    enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
                }
                else
                {
                    enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                    flashActive = false;
                }
                flashCounter -= Time.deltaTime;
            }

            if (currentHealth == 0)
            {
                Destroy(gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            flashActive = true;
            flashCounter = flashLength;
            Debug.Log("Damage Taken");
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Bullet")
            {
                Vector2 difference = transform.position - collision.transform.position;
                transform.position = new Vector2(transform.position.x + difference.x,
                    transform.position.y + difference.y);
            }
            if (collision.tag == "Sword")
            {
                Vector2 difference = transform.position - collision.transform.position;
                transform.position = new Vector2(transform.position.x + difference.x,
                    transform.position.y + difference.y);
            }
        }
    }
}

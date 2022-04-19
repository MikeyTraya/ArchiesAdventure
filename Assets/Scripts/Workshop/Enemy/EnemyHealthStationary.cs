using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyHealthStationary : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;

        public GameObject floatingText;

        private bool flashActive;
        [SerializeField]
        private float flashLength = 0f;
        private float flashCounter = 0f;
        private SpriteRenderer enemySprite;

        CapsuleCollider2D capsuleCollider;

        private void Start()
        {
            enemySprite = GetComponent<SpriteRenderer>();
            currentHealth = maxHealth;
            capsuleCollider = GetComponent<CapsuleCollider2D>();
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
                    capsuleCollider.enabled = true;
                }
                flashCounter -= Time.deltaTime;
            }

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            GameObject points = Instantiate(floatingText, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
            currentHealth -= damage;
            flashActive = true;
            capsuleCollider.enabled = false;
            flashCounter = flashLength;
            Debug.Log("Damage Taken");
        }
    }
}

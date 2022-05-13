using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyHealthStationary : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;

        private bool flashActive;
        [SerializeField]
        private float flashLength = 0f;
        private float flashCounter = 0f;
        private SpriteRenderer enemySprite;

        public Transform enemyTransform;

        private ParticleSystem particle;

        public GameObject floatingText;
        public GameObject enemyBody;
        public GameObject[] lootDrops;

        private int randomNumber;

        private void Awake()
        {
            particle = GetComponentInChildren<ParticleSystem>();
        }

        private void Start()
        {
            randomNumber = Random.Range(0, lootDrops.Length);
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

            
        }

        public void TakeDamage(int damage)
        {
            GameObject points = Instantiate(floatingText, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
            EffectsManager.Instance.Play("EnemyHurt");
            currentHealth -= damage;
            flashActive = true;
            flashCounter = flashLength;
            Debug.Log("Damage Taken");

            if (currentHealth <= 0)
            {
                StartCoroutine(Death());
            }
        }

        private IEnumerator Death()
        {
            particle.Play();
            EffectsManager.Instance.Play("EnemyDeath");
            enemyBody.GetComponent<SpriteRenderer>().enabled = false;
            enemyBody.GetComponent<CapsuleCollider2D>().enabled = false;
            enemyBody.GetComponent<Animator>().enabled = false;
            enemyTransform.GetComponent<Transform>().Find("Shadow").gameObject.SetActive(false);
            yield return new WaitForSeconds(.9f);
            Destroy(gameObject);
            Instantiate(lootDrops[randomNumber], transform.position, Quaternion.identity);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class PlayerManager : MonoBehaviour
    {
        public static event Action OnPlayerDeath;

        public int maxHealth;
        public int currentHealth;

        private float invinsibleAmount;

        public GameObject floatingText;

        private bool isAttacked = false;
        private bool flashActive;
        [SerializeField]
        private float flashLength = 0f;
        private float flashCounter = 0f;
        private SpriteRenderer playerSprite;

        CapsuleCollider2D capsuleCollider;

        public static PlayerManager Instance;
        void Awake() => Instance = this;

        private void Start()
        {
            playerSprite = GetComponent<SpriteRenderer>();
            currentHealth = maxHealth;
            capsuleCollider = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (flashActive)
            {
                if (flashCounter > flashLength * .99f)
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
                }
                else if (flashCounter > flashLength * .82f)
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
                else if (flashCounter > flashLength * .66f)
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
                }
                else if (flashCounter > flashLength * .49f)
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
                else if (flashCounter > flashLength * .33f)
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
                }
                else if (flashCounter > flashLength * .16f)
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
                else if (flashCounter > 0)
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
                }
                else
                {
                    playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                    flashActive = false;
                    capsuleCollider.enabled = true;
                    isAttacked = false;
                }
                flashCounter -= Time.deltaTime;
            }

            if (currentHealth <= 0)
            {
                OnPlayerDeath?.Invoke();
            }

            if (invinsibleAmount > 0)
            {
                invinsibleAmount -= Time.deltaTime;
            }

        }

        public void TakeDamage(int damage)
        {
            if (invinsibleAmount <= 0)
            {
                GameObject points = Instantiate(floatingText, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
                currentHealth -= damage;
                flashActive = true;
                isAttacked = true;
                capsuleCollider.enabled = false;
                flashCounter = flashLength;
                Debug.Log("Damage Taken");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && isAttacked)
            {
                Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
                Vector2 difference = (transform.position - collision.transform.position).normalized;
                transform.position = new Vector2(transform.position.x + difference.x,
                transform.position.y + difference.y);
                return;
            }
            return;
        }

        public void Invinsible(float delay, float invinsibleLength)
        {
            if(delay > 0)
            {
                StartCoroutine(StartInvinsible(delay, invinsibleLength));
            }
            else
            {
                invinsibleAmount = invinsibleLength;
            }
        }

        IEnumerator StartInvinsible(float delay, float invinsibleLength)
        {
            yield return new WaitForSeconds(delay);
            Debug.Log("Invinsible");
            invinsibleAmount = invinsibleLength;
        }
    }
}

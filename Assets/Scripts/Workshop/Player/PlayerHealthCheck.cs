using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class PlayerHealthCheck : MonoBehaviour
    {
        public static event Action OnPlayerDeath;

        public int maxHealth;
        public int currentHealth;

        private bool flashActive;
        [SerializeField]
        private float flashLength = 0.5f;
        private float flashCounter = 0f;
        private SpriteRenderer playerSprite;

        private void Start()
        {
            playerSprite = GetComponent<SpriteRenderer>();
            currentHealth = maxHealth;
        }

        private void Update()
        {
            currentHealth = GameManager.Instance.health;
            maxHealth = GameManager.Instance.numberOfHearts;

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
                }
                flashCounter -= Time.deltaTime;
            }

            if (currentHealth <= 0)
            {
                OnPlayerDeath?.Invoke();
            }
        }

        public void TakeDamage()
        {
            if (GameManager.Instance.health != 0)
            {
                CameraShake.Instance.ShakeCamera(3f, 0.15f);
                EffectsManager.Instance.Play("PlayerHurt");
                flashActive = true;
                flashCounter = flashLength;
            }
        }
    }
}

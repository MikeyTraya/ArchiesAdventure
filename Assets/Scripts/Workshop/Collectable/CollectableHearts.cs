using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace WarriorOrigins
{
    public class CollectableHearts : MonoBehaviour, ICollectable
    {
        public static event Action OnHeartsCollected;

        private ParticleSystem particle;

        private SpriteRenderer spriteRenderer;

        private CircleCollider2D circleCollider2D;

        private void Awake()
        {
            particle = GetComponentInChildren<ParticleSystem>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            circleCollider2D = GetComponent<CircleCollider2D>();
        }

        public void Collect()
        {
            if (GameManager.Instance.health < GameManager.Instance.numberOfHearts)
            {
                StartCoroutine(Get());
            }
        }

        private IEnumerator Get()
        {
            particle.Play();
            EffectsManager.Instance.Play("Pickups");
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
            OnHeartsCollected?.Invoke();
            yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;
using System;

namespace WarriorOrigins
{
    public class CollectableBombs : MonoBehaviour, ICollectable
    {
        public static event Action OnBombCollected;

        private ParticleSystem particle;

        private SpriteRenderer spriteRenderer;

        private CircleCollider2D circleCollider2D;

        public Transform collectedBomb;

        private void Awake()
        {
            particle = GetComponentInChildren<ParticleSystem>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            circleCollider2D = GetComponent<CircleCollider2D>();
        }

        public void Collect()
        {
            StartCoroutine(Get());
        }
        private IEnumerator Get()
        {
            particle.Play();
            EffectsManager.Instance.Play("Pickups");
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
            collectedBomb.transform.GetChild(2).gameObject.SetActive(false);
            OnBombCollected?.Invoke();
            yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
            Destroy(gameObject);

        }
    }
}

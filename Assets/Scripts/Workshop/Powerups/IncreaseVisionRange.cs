using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class IncreaseVisionRange : MonoBehaviour
    {
        public Vector3 innerVisionamount;
        public Vector3 outerVisionamount;

        private ParticleSystem particle;

        private BoxCollider2D boxCollider2D;

        public Transform powerUp;

        private void Awake()
        {
            particle = GetComponentInChildren<ParticleSystem>();
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
                return;

            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.innerVisionRange = innerVisionamount;
                GameManager.Instance.outerVisionRange = outerVisionamount;

                StartCoroutine(OnCollect());
            }
        }
        private IEnumerator OnCollect()
        {
            particle.Play();
            powerUp.transform.GetChild(0).gameObject.SetActive(false);
            powerUp.transform.GetChild(1).gameObject.SetActive(false);
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
            gameObject.SetActive(false);
        }
    }
}

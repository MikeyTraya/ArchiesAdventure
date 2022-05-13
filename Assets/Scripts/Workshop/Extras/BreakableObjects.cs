using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WarriorOrigins
{
    public class BreakableObjects : MonoBehaviour
    {
        private ParticleSystem particle;

        public GameObject barrel;

        public GameObject[] lootDrops;

        private int randomNumber;

        public int durability;

        private void Awake()
        {
            particle = GetComponentInChildren<ParticleSystem>();
        }

        private void Start()
        {
            randomNumber = Random.Range(0, lootDrops.Length);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Sword"))
            {
                durability--;
                particle.Play();
                EffectsManager.Instance.Play("ObjectsHit");
                if (durability <= 0)
                {
                    StartCoroutine(Break());
                }
                
            }

            if (collision.gameObject.CompareTag("Bullet"))
            {
                durability--;
                particle.Play();
                EffectsManager.Instance.Play("ObjectsHit");
                if (durability <= 0)
                {
                    StartCoroutine(Break());
                }
            }

            if (collision.gameObject.CompareTag("Bombs"))
            {
                durability -= durability;
                particle.Play();
                EffectsManager.Instance.Play("ObjectsHit");
                if (durability <= 0)
                {
                    StartCoroutine(Break());
                }
            }
        }

        private IEnumerator Break()
        {
            particle.Play();
            EffectsManager.Instance.Play("BreakObjects");
            barrel.transform.GetChild(1).gameObject.SetActive(false);
            barrel.transform.GetChild(2).gameObject.SetActive(true);
            barrel.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
            Instantiate(lootDrops[randomNumber], transform.position, Quaternion.identity);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WarriorOrigins
{
    public class FakeHeightProjectiles : MonoBehaviour
    {
        public enum State
        {
            MainGame,
            Tutorial,
        }

        public State state;

        public UnityEvent onGroundHitEvent;

        public GameObject bomb;
        public int damage;

        public Transform bombObject;
        public Transform bombBody;
        public Transform bombShadow;

        public float gravity = -10;
        public Vector2 groundVelocity;
        public float verticalVelocity;

        public bool isGrounded;

        private ParticleSystem particle;

        private void Awake()
        {
            particle = GetComponentInChildren<ParticleSystem>();
        }

        private void Start()
        {
            damage = GameManager.Instance.bombsDamage;
        }

        private void Update()
        {
            UpdatePosition();
            CheckGroundHit();
        }

        public void InitializeBomb(Vector2 groundVelocity, float verticalVelocity)
        {
            this.groundVelocity = groundVelocity;
            this.verticalVelocity = verticalVelocity;
        }

        void UpdatePosition()
        {
            if (!isGrounded)
            {
                verticalVelocity += gravity * Time.deltaTime;
                bombBody.position += new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
            }
            

            bombObject.position += (Vector3)groundVelocity * Time.deltaTime;
        }

        void CheckGroundHit()
        {
            if (bombBody.position.y < bombObject.position.y && !isGrounded)
            {
                bombBody.position = bombObject.position;
                isGrounded = true;
                GroundHit();
            }
        }

        void GroundHit()
        {
            onGroundHitEvent.Invoke();
        }

        public void Stick()
        {
            StartCoroutine(DestroyBomb());
            StartCoroutine(BombTicking());
        }

        public IEnumerator DestroyBomb()
        {
            groundVelocity = Vector2.zero;
            yield return new WaitForSeconds(3f);
            particle.Play();
            bomb.transform.GetChild(0).gameObject.SetActive(false);
            bomb.transform.GetChild(1).gameObject.SetActive(false);
            bomb.GetComponent<CircleCollider2D>().enabled = true;
            bomb.transform.GetChild(3).gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
            bomb.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }

        IEnumerator BombTicking()
        {
            while (true)
            {
                bomb.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                yield return new WaitForSeconds(.1f);
                bomb.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                yield return new WaitForSeconds(.1f);
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            if (collision.gameObject.CompareTag("EnemyStationary"))
            {
                collision.gameObject.GetComponent<EnemyHealthStationary>().TakeDamage(damage);
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                switch (state)
                {
                    case State.MainGame:
                        GameManager.Instance.TakeDamage(damage);
                        break;
                    case State.Tutorial:
                        if (GameManager.Instance.health != 1)
                            GameManager.Instance.TakeDamage(damage);
                        break;
                    default:
                        break;
                }
                
            }

            if (collision.gameObject.CompareTag("EnemyProjectiles"))
            {
                return;
            }

        }
    }
}

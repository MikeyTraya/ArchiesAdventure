using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyFollow : MonoBehaviour
    {
        public enum State
        {
            MainGame,
            Tutorial,
        }

        public State state;

        public float speed;
        public float minimumDistance;
        public float agroRange;
        public int damage;
        private Vector2 movement;

        Rigidbody2D rb;

        bool rightFace = true;
        bool isFollowingPlayer = false;
        bool isAttacking = true;

        //AI
        public bool isPatrolling = false;
        private float latestDirectionChangeTime;
        private float directionChangeTime;
        private float distanceFromPlayer;
        private readonly float characterVelocity = 1.5f;
        private Vector2 movementDirection;
        private Vector2 movementPerSecond;
        private Vector3 direction;

        public GameObject player;

        void Start()
        {
            latestDirectionChangeTime = 0f;
            CalcuateNewMovementVector();
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            AIMovement();
        }

        void FixedUpdate()
        {
            if (isPatrolling == true)
            {
                directionChangeTime = Random.Range(1, 3);

                //if the changeTime was reached, calculate a new movement vector
                if (Time.time - latestDirectionChangeTime > directionChangeTime)
                {
                    latestDirectionChangeTime = Time.time;
                    CalcuateNewMovementVector();
                }
                //Enemy moving
                rb.MovePosition((Vector2)transform.position + (movementPerSecond * Time.deltaTime));
            }

            if (isFollowingPlayer == true)
            {
                FollowPlayer();
            }
        }

        void AIMovement()
        {
            switch (state)
            {
                case State.MainGame:
                    distanceFromPlayer = Vector2.Distance(transform.position, LevelGenerator.Instance.player.transform.position);
                    break;
                case State.Tutorial:
                    distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
                    break;
                default:
                    break;
            }
            

            if (distanceFromPlayer <= agroRange)
            {
                if (distanceFromPlayer > minimumDistance)
                {
                    switch (state)
                    {
                        case State.MainGame:
                            if (transform.position.x >= LevelGenerator.Instance.player.transform.position.x && rightFace)
                            {
                                Flip();
                            }
                            else if (transform.position.x <= LevelGenerator.Instance.player.transform.position.x && !rightFace)
                            {
                                Flip();
                            }
                            break;
                        case State.Tutorial:
                            if (transform.position.x >= player.transform.position.x && rightFace)
                            {
                                Flip();
                            }
                            else if (transform.position.x <= player.transform.position.x && !rightFace)
                            {
                                Flip();
                            }
                            break;
                        default:
                            break;
                    }
                    

                    isFollowingPlayer = true;
                    isPatrolling = false;
                }
                else
                {
                    //attack animation
                    isFollowingPlayer = false;
                    isPatrolling = false;
                }
            }
            else
            {
                isFollowingPlayer = false;
                isPatrolling = true;
            }
        }

        void FollowPlayer()
        {
            switch (state)
            {
                case State.MainGame:
                    direction = LevelGenerator.Instance.player.transform.position - transform.position;
                    direction.Normalize();
                    movement = direction;
                    rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
                    break;
                case State.Tutorial:
                    direction = player.transform.position - transform.position;
                    direction.Normalize();
                    movement = direction;
                    rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
                    break;
                default:
                    break;
            }
        }

        //AI Patrolling
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ("Walls") || collision.gameObject.tag == ("Enemy"))
            {
                CalcuateNewMovementVector();
                return;
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            switch (state)
            {
                case State.MainGame:
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        if (isAttacking)
                        {
                            StartCoroutine(WaitForSeconds());
                            GameManager.Instance.TakeDamage(damage);
                        }
                    }
                    break;
                case State.Tutorial:
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        if (isAttacking && GameManager.Instance.health != 1)
                        {
                            StartCoroutine(WaitForSeconds());
                            GameManager.Instance.TakeDamage(damage);
                        }
                    }
                    break;
                default:
                    break;
            }
            
        }

        IEnumerator WaitForSeconds()
        {
            isAttacking = false;
            yield return new WaitForSecondsRealtime(1);
            isAttacking = true;
        }

        void CalcuateNewMovementVector()
        {
            movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            movementPerSecond = movementDirection * characterVelocity;
        }

        void Flip()
        {
            rightFace = !rightFace;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}

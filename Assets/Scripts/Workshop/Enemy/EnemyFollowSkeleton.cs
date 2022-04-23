using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyFollowSkeleton : MonoBehaviour
    {
        public float speed;
        public float minimumDistance;
        public float agroRange;
        public float attackCooldown;
        private float actCooldown;
        public int damage;

        Animator animator;
        Rigidbody2D rb;

        bool rightFace = true;
        bool isRunning = false;
        bool isAttacking = false;
        bool isFollowingPlayer = false;

        private Vector2 movement;

        //AI
        private bool isPatrolling = false;
        private float latestDirectionChangeTime;
        private float directionChangeTime;
        private readonly float characterVelocity = 3f;
        private Vector2 movementDirection;
        private Vector2 movementPerSecond;

        void Start()
        {
            animator = GetComponent<Animator>();
            latestDirectionChangeTime = 0f;
            CalcuateNewMovementVector();
            rb = GetComponent<Rigidbody2D>();
            
        }

        void Update()
        {
            AIAnimation();
            AIMovement();
            attackCooldown = Random.Range(.5f, 1f);
        }

        void FixedUpdate()
        {
            if (isPatrolling == true)
            {
                directionChangeTime = Random.Range(1, 3);

                if (Time.time - latestDirectionChangeTime > directionChangeTime)
                {
                    latestDirectionChangeTime = Time.time;
                    CalcuateNewMovementVector();
                }

                isRunning = true;
                rb.MovePosition((Vector2)transform.position + (movementPerSecond * Time.deltaTime));
            }

            if (isFollowingPlayer == true)
            {
                FollowPlayer();
            }
        }

        //AI Patrolling
        void AIMovement()
        {
            float distanceFromPlayer = Vector2.Distance(transform.position, LevelGenerator.Instance.player.transform.position);

            if (distanceFromPlayer < agroRange)
            {
                if (distanceFromPlayer > minimumDistance)
                {

                    if (transform.position.x >= LevelGenerator.Instance.player.transform.position.x && rightFace)
                    {
                        Flip();
                    }
                    else if (transform.position.x <= LevelGenerator.Instance.player.transform.position.x && !rightFace)
                    {
                        Flip();
                    }

                    isFollowingPlayer = true;
                    isRunning = true;
                    isPatrolling = false;
                    isAttacking = false;
                }
                else 
                {
                    //attack sequence
                    isFollowingPlayer = false;
                    isRunning = false;
                    isPatrolling = false;
                    isAttacking = true;

                    if (actCooldown <= 0 && isAttacking)
                    {
                        
                        actCooldown = attackCooldown;
                        animator.SetTrigger("isAttacking");
                    }
                    else
                    {
                        actCooldown -= Time.deltaTime;
                    }
                }
            }
            else
            {
                isFollowingPlayer = false;
                isPatrolling = true;
                isAttacking = false;
            }
        }

        void FollowPlayer()
        {
            Vector3 direction = LevelGenerator.Instance.player.transform.position - transform.position;
            direction.Normalize();
            movement = direction;
            rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (isAttacking)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    GameManager.Instance.TakeDamage(damage);
                    return;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Enemy"))
            {
                CalcuateNewMovementVector();
            }
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

        void AIAnimation()
        {
            animator.SetBool("isRunning", isRunning);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyFollowSkeleton : MonoBehaviour
    {
        public LevelGenerator target;

        public float speed;
        public float minimumDistance;
        public float agroRange;
        
        Animator animator;
        Rigidbody2D rb;

        bool rightFace = true;
        bool isRunning = false;
        bool isFollowingPlayer = false;

        public Vector2 movement;
        public Vector2 newPosition;

        //AI
        public bool isPatrolling = false;
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
            float distanceFromPlayer = Vector2.Distance(transform.position, target.player.transform.position);

            if (distanceFromPlayer < agroRange)
            {
                if (distanceFromPlayer > minimumDistance)
                {

                    if (transform.position.x >= target.player.transform.position.x && rightFace)
                    {
                        Flip();
                    }
                    else if (transform.position.x <= target.player.transform.position.x && !rightFace)
                    {
                        Flip();
                    }

                    isFollowingPlayer = true;
                    isRunning = true;
                    isPatrolling = false;
                }
                else 
                {
                    //attack animation
                    animator.SetTrigger("isAttacking");

                    isFollowingPlayer = false;
                    isRunning = false;
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
            Vector3 direction = target.player.transform.position - transform.position;
            direction.Normalize();
            movement = direction;
            rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
        }

        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ("Walls") || collision.gameObject.tag == ("Enemy"))
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

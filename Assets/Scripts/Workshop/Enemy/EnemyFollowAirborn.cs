using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyFollowAirborn : MonoBehaviour
    {
        public float speed;
        public float minimumDistance;
        public float agroRange;

        private Vector2 movement;

        Rigidbody2D rb;

        Animator animator;

        bool rightFace = true;
        bool isMoving = false;
        bool isFollowingPlayer = false;

        void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            AIAnimation();
            AIMovement();
        }

        void FixedUpdate()
        {
            if (isFollowingPlayer == true)
            {
                FollowPlayer();
            }
        }

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
                }
                else
                {
                    isFollowingPlayer = false;
                }
            }
            
        }

        void FollowPlayer()
        {
            isMoving = true;
            Vector3 direction = LevelGenerator.Instance.player.transform.position - transform.position;
            direction.Normalize();
            movement = direction;
            rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
        }

        void Flip()
        {
            rightFace = !rightFace;
            transform.Rotate(0f, 180f, 0f);
        }

        void AIAnimation()
        {
            animator.SetBool("isMoving", isMoving);
        }
    }
}

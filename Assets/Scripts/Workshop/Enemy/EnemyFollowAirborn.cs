using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyFollowAirborn : MonoBehaviour
    {
        public float speed;
        public LevelGenerator target;
        public float minimumDistance;
        public float agroRange;

        private Vector2 movement;

        Rigidbody2D rb;

        Animator animator;

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
            float distanceFromPlayer = Vector2.Distance(transform.position, target.player.transform.position);

            if (distanceFromPlayer < agroRange)
            {
                if (distanceFromPlayer > minimumDistance)
                {
                    isFollowingPlayer = true;
                }
                else
                {
                    isFollowingPlayer = false;
                }
            }
            else
            {
                isFollowingPlayer = false;
                isMoving = false;
            }
        }

        void FollowPlayer()
        {
            isMoving = true;
            Vector3 direction = target.player.transform.position - transform.position;
            direction.Normalize();
            movement = direction;
            transform.Translate(movement * speed * Time.deltaTime);
        }

        void AIAnimation()
        {
            animator.SetBool("isMoving", isMoving);
        }
    }
}

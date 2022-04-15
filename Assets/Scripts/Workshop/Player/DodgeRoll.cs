using System;
using UnityEngine;

namespace WarriorOrigins
{
    public class DodgeRoll : MonoBehaviour
    {
        private Rigidbody2D rb;

        private Animator animator;

        public GameObject player;

        Vector2 movement;
        Vector3 lastMoveDirection;

        public float dodgeCooldown = 1f;
        private float actCooldown;
        public float pushAmount;

        public bool Roll;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            movement = new Vector2(x, y).normalized;
            
            if (movement.x != 0 || movement.y != 0)
            {
                lastMoveDirection = movement;
            }

            Roll = Input.GetKeyDown(KeyCode.Space);
            
            if (actCooldown <= 0)
            {
                animator.ResetTrigger("isDodging");
                if (Roll)
                {
                    Dodge();
                }
                else
                {
                    player.transform.GetChild(0).gameObject.SetActive(false);
                    player.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            else
            {
                actCooldown -= Time.deltaTime;
                
            }
        }

        private void Dodge()
        {
            actCooldown = dodgeCooldown;
            rb.AddForce(lastMoveDirection * (pushAmount + Time.deltaTime), ForceMode2D.Force);

            animator.SetTrigger("isDodging");

            player.transform.GetChild(0).gameObject.SetActive(true);
            player.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}

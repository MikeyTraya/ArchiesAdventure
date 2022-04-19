using UnityEngine;

namespace WarriorOrigins
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 7f;

        public Rigidbody2D rb;
        private Camera cam;

        Vector2 movement;
        Vector2 mousePos;

        bool rightFace = true;
        bool isRunning = false;

        Animator animator;
        private void OnEnable()
        {
            PlayerManager.OnPlayerDeath += DisablePlayerMovement;
        }

        private void OnDisable()
        {
            PlayerManager.OnPlayerDeath -= DisablePlayerMovement;
        }

        void Start()
        {
            animator = GetComponent<Animator>();
            cam = Camera.main;
            EnablePlayerMovement();
        }

        void Update()
        {
            PlayerInput();
            PlayerAnimation();
        }

        void FixedUpdate()
        {
            Movement();
        }

        void PlayerInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            movement = new Vector2(x, y).normalized;

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < transform.position.x && rightFace)
            {
                Flip();
            }
            else if (mousePos.x > transform.position.x && !rightFace)
            {
                Flip();
            }
        }

        void Flip()
        {
            rightFace = !rightFace;
            transform.Rotate(0f, 180f, 0f);
        }

        void Movement()
        {
            if (movement != Vector2.zero)
            {
                rb.velocity = movement * moveSpeed * moveSpeed;
                isRunning = true;
            }
            else
            {
                rb.velocity = Vector2.zero;
                isRunning = false;
            }
        }

        void PlayerAnimation()
        {
            animator.SetBool("isRunning", isRunning);
        }

        private void DisablePlayerMovement()
        {
            animator.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
        }

        private void EnablePlayerMovement()
        {
            animator.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }
}
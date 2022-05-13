using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class DeathManager : MonoBehaviour
    {
        public GameObject gameOverMenu;
        public GameObject minimap;

        public static bool isDead;

        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            
            PlayerHealthCheck.OnPlayerDeath += EnableGameOverMenu;
            
        }

        private void OnDisable()
        {
            isDead = false;
            animator.SetBool("isOpen", false);
            PlayerHealthCheck.OnPlayerDeath -= EnableGameOverMenu;
        }

        public void EnableGameOverMenu()
        {
            isDead = true;
            animator.SetBool("isOpen", true);
            gameOverMenu.SetActive(true);
            minimap.SetActive(false);
        }
    }
}

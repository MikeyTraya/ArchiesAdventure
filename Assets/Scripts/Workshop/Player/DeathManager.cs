using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class DeathManager : MonoBehaviour
    {
        public GameObject gameOverMenu;
        public GameObject minimap;

        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            
            PlayerManager.OnPlayerDeath += EnableGameOverMenu;
            
        }

        private void OnDisable()
        {
            animator.SetBool("isOpen", false);
            PlayerManager.OnPlayerDeath -= EnableGameOverMenu;
        }

        public void EnableGameOverMenu()
        {
            animator.SetBool("isOpen", true);
            gameOverMenu.SetActive(true);
            minimap.SetActive(false);


        }
    }
}

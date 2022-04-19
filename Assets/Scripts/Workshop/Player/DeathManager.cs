using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class DeathManager : MonoBehaviour
    {
        public GameObject gameOverMenu;

        private void OnEnable()
        {
            PlayerManager.OnPlayerDeath += EnableGameOverMenu;
        }

        private void OnDisable()
        {
            PlayerManager.OnPlayerDeath -= EnableGameOverMenu;
        }

        public void EnableGameOverMenu()
        {
            gameOverMenu.SetActive(true);
        }
    }
}

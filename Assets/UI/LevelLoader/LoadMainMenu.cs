using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class LoadMainMenu : MonoBehaviour
    {
        public void Update()
        {
            bool startGame = Input.GetKeyDown(KeyCode.Space);
            if (startGame)
            {
                SpaceToMainMenu();
            }
        }

        public void SpaceToMainMenu()
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}

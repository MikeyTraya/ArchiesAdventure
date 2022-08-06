using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class LoadGame : MonoBehaviour
    {
        public void Update()
        {
            bool startGame = Input.GetKeyDown(KeyCode.Space);
            if (startGame)
            {
                SpaceToMainMenu();
                GameManager.Instance.GameReset();
            }
        }

        public void SpaceToMainMenu()
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}

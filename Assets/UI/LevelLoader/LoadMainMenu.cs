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
                GameManager.Instance.GameReset();
                SpaceToMainMenu();
            }
        }

        public void SpaceToMainMenu()
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        private void OnEnable()
        {
            StartCoroutine(PlayerDeath());
        }

        IEnumerator PlayerDeath()
        {
            yield return new WaitForSeconds(0.5f);
            GameManager.Instance.OnPlayerDeath();
        }
    }
}

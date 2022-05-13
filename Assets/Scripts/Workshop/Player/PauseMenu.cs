using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenuCanvas;
        public static bool isPause;

        private void Start()
        {
            pauseMenuCanvas.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPause)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void PauseGame()
        {
            EffectsManager.Instance.Play("PauseMenu");
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
        }

        public void ResumeGame()
        {
            EffectsManager.Instance.Play("PauseMenu");
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            isPause = false;
        }

        public void GoToMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Main");
        }
    }
}

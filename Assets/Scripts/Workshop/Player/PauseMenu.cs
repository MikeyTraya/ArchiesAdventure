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
            Click();
            EffectsManager.Instance.Play("PauseMenu");
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
        }

        public void ResumeGame()
        {
            Click();
            EffectsManager.Instance.Play("PauseMenu");
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            isPause = false;
        }

        public void GoToMainMenu()
        {
            Click();
            Time.timeScale = 1f;
            isPause = false;
            GameManager.Instance.GameReset();
            SceneManager.LoadScene("Main");
        }

        public void Click()
        {
            EffectsManager.Instance.Play("Click");
        }
    }
}

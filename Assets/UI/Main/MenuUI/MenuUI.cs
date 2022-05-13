using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class MenuUI : MonoBehaviour
    {

        public static MenuUI Instance;
        void Awake() => Instance = this;

        private void Start()
        {
            transform.localScale = Vector2.zero;
            MusicManager.Instance.Play("MainMenuTheme");
            MusicManager.Instance.Stop("GameTheme");
            MusicManager.Instance.Stop("GameOverTheme");
        }

        public void Open()
        {
            transform.LeanScale(Vector2.one, .75f).setEaseSpring();
            this.enabled = false;
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void SetMusicVolume(float volume)
        {
            MusicManager.Instance.volume = volume;
        }
        public void SetEffectsVolume(float volume)
        {
            EffectsManager.Instance.volume = volume;
        }

        public void Click()
        {
            EffectsManager.Instance.Play("Click");
        }

        public void QuitGame()
        {
            Application.Quit();
        }


    }
}

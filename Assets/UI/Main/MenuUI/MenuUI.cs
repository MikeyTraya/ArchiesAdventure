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

        public void SetVolume(float volume)
        {
            Debug.Log(volume);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

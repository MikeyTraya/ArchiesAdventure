using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class LevelLoader : MonoBehaviour
    {
        public Animator transition;

        public float transitionTime = 1f;

        public void LoadTutorialLevel()
        {
            StartCoroutine(LoadTLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        IEnumerator LoadTLevel(int levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(levelIndex);
        }

        public void LoadMainLevel()
        {
            StartCoroutine(LoadMLevel("Level1"));
        }

        IEnumerator LoadMLevel(string levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(levelIndex);
        }


    }
}

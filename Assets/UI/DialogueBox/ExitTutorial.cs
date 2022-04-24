using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class ExitTutorial : MonoBehaviour
    {
        public void ExitScene()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            yield return new WaitForSeconds(.1f);

            SceneManager.LoadScene(levelIndex);
        }
    }
}

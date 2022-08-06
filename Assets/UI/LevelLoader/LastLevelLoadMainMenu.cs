using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class LastLevelLoadMainMenu : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
            GameManager.Instance.GameReset();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace WarriorOrigins
{
    public class LevelNameOpenner : MonoBehaviour
    {
        public GameObject levelNamePlaceholder;

        public TextMeshProUGUI namePlaceholder;

        void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                namePlaceholder.text = "Cave Level 1";
                StartCoroutine(Display());
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                namePlaceholder.text = "Cave Level 2";
                StartCoroutine(Display());
            }
            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                namePlaceholder.text = "Cave Level 3";
                StartCoroutine(Display());
            }
            else if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                namePlaceholder.text = "Final Level";
                StartCoroutine(Display());
            }
            else
            {
                levelNamePlaceholder.SetActive(false);
            }
        }

        IEnumerator Display()
        {
            levelNamePlaceholder.SetActive(true);
            yield return new WaitForSeconds(3f);
            levelNamePlaceholder.SetActive(false);

        }
    }
}

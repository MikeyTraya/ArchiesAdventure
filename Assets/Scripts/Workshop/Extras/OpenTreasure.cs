using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class OpenTreasure : MonoBehaviour
    {
        public bool isOpen;

        public Animator animator;

        public void OpenBox()
        {
            if (!isOpen)
            {
                isOpen = true;
                animator.SetBool("isOpen", isOpen);
                StartCoroutine(GoToLastScene());
            }
            
        }

        IEnumerator GoToLastScene()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class BombController : MonoBehaviour
    {
        public enum State
        {
            MainLevels,
            Tutorial,
        }

        public State state;

        public GameObject tutorialBombs;
        public GameObject mainGameBombs;
        public Vector2 groundDispenseVelocity;
        public Vector2 verticalDispenseVelocity;

        private void Update()
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                state = State.MainLevels;
                MainThrowBomb();
            }
            else
            {
                state = State.Tutorial;
                TutorialThrowBomb();
            }
            
        }

        void TutorialThrowBomb()
        {
            if (GameManager.Instance.totalBombs == 0)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(tutorialBombs, transform.position, Quaternion.identity);
                GameManager.Instance.BombsUse();
            }
        }

        void MainThrowBomb()
        {
            if (GameManager.Instance.totalBombs == 0)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(mainGameBombs, transform.position, Quaternion.identity);
                GameManager.Instance.BombsUse();
            }
        }
    }
}

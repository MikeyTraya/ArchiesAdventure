using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class MainMenu : MonoBehaviour
    {

        private Animator animator;
        bool startGame;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        public void Update()
        {
            startGame = Input.GetKeyDown(KeyCode.Space);
            if (startGame)
            {
                StartGame();
            }
        }

        void StartGame()
        {
            animator.SetBool("isGameStart", startGame);
        }
    }
}

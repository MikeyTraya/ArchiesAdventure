using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WarriorOrigins
{
    public class PlayerGameUpdate : MonoBehaviour
    {
        public int health;
        public int numberOfHearts;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHearts;

        

        void Update()
        {
            health = PlayerManager.Instance.currentHealth;
            numberOfHearts = PlayerManager.Instance.maxHealth;


            if (health > numberOfHearts)
            {
                health = numberOfHearts;
            }

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHearts;
                }

                if (i < numberOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }    
        }
    }
}

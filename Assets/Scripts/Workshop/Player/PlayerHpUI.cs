using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WarriorOrigins
{
    public class PlayerHpUI : MonoBehaviour
    {
        int health;
        int numberOfHearts;

        [Header("Other Info")]
        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHearts;

        private void Update()
        {
            health = GameManager.Instance.health;
            numberOfHearts = GameManager.Instance.numberOfHearts;

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

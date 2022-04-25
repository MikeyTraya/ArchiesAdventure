using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WarriorOrigins
{
    public class GameManager : MonoBehaviour
    {
        public enum State
        {
            Tutorial,
            MainLevels,
        }

        public State state;

        public int health;
        public int numberOfHearts;

        public float invinsibleAmount;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHearts;

        public GameObject player;

        public static GameManager Instance;
        void Awake() => Instance = this;

        private void Start()
        {
            numberOfHearts = health;
        }

        void Update()
        {
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

            if (invinsibleAmount > 0)
            {
                invinsibleAmount -= Time.deltaTime;
            }
        }


        public void TakeDamage(int damage)
        {
            if (invinsibleAmount <= 0)
            {
                switch (state)
                {
                    case State.Tutorial:
                        health -= damage;
                        player.GetComponent<PlayerManager>().TakeDamage();
                        Debug.Log("Player was hit");
                        break;
                    case State.MainLevels:
                        health -= damage;
                        LevelGenerator.Instance.player.GetComponent<PlayerManager>().TakeDamage();
                        Debug.Log("Player was hit");
                        break;
                    default:
                        break;
                }
            }
        }

        public void TakeDamageUndodgeable(int damage)
        {
            switch (state)
            {
                case State.Tutorial:
                    health -= damage;
                    player.GetComponent<PlayerManager>().TakeDamage();
                    Debug.Log("Player was hit");
                    break;
                case State.MainLevels:
                    health -= damage;
                    LevelGenerator.Instance.player.GetComponent<PlayerManager>().TakeDamage();
                    Debug.Log("Player was hit");
                    break;
                default:
                    break;
            }
        }

        public void Invinsible(float delay, float invinsibleLength)
        {
            if (delay > 0)
            {
                StartCoroutine(StartInvinsible(delay, invinsibleLength));
            }
            else
            {
                invinsibleAmount = invinsibleLength;
            }
        }
        IEnumerator StartInvinsible(float delay, float invinsibleLength)
        {
            yield return new WaitForSeconds(delay);
            Debug.Log("Invinsible");
            invinsibleAmount = invinsibleLength;
        }
    }
}

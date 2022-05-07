using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        [Header("Player Info")]
        public int health;
        public int numberOfHearts;
        public int dodgeStamina;
        public float invinsibleAmount;
        public Vector3 innerVisionRange;
        public Vector3 outerVisionRange;
        public int powerUpBronzeID;
        public int powerUpSilverID;
        public int powerUpGoldID;
        public bool powerUp1isCollected = false;
        public bool powerUp2isCollected = false;
        public bool powerUp3isCollected = false;

        [Header("CollectedItems Info")]
        public int totalCoins;
        public int totalShovels;
        public int totalBombs;

        [Header("Weapon Info")]
        public int currentMeleeWeaponEquipped;
        public int currentRangeWeaponEquipped;
        public int rangeWeaponStaminaCost;
        public int meleeWeaponStaminaCost;
        public int meleeDamage;
        public int rangeDamage;
        public int bombsDamage;

        public GameObject player;

        public static GameManager Instance;
        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            numberOfHearts = health;
        }

        void Update()
        {
            

            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                state = State.MainLevels;
            }
            else
            {
                state = State.Tutorial;
            }

            if (health > numberOfHearts)
            {
                health = numberOfHearts;
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

        private void OnEnable()
        {
            CollectableHearts.OnHeartsCollected += AddHP;
        }

        private void OnDisable()
        {
            CollectableHearts.OnHeartsCollected -= AddHP;
        }

        public void AddHP()
        {
            health++;
            if (health >= numberOfHearts)
            {
                health = numberOfHearts;
            }
        }

        public void ShovelAdd()
        {
            totalShovels++;
        }

        public void ShovelUse()
        {
            totalShovels--;
        }

        public void CoinUse()
        {
            totalCoins--;
        }

        public void BombsUse()
        {
            totalBombs--;
        }

        public void NotifyPlayer()
        {
            switch (state)
            {
                case State.Tutorial:
                    player.transform.GetChild(4).gameObject.SetActive(true);
                    break;
                case State.MainLevels:
                    LevelGenerator.Instance.player.transform.GetChild(4).gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        public void DenotifyPlayer()
        {
            switch (state)
            {
                case State.Tutorial:
                    player.transform.GetChild(4).gameObject.SetActive(false);
                    break;
                case State.MainLevels:
                    LevelGenerator.Instance.player.transform.GetChild(4).gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            
        }
    }
}

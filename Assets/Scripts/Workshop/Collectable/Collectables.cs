using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace WarriorOrigins
{
    public class Collectables : MonoBehaviour
    {
        public TMP_Text totalCoins;
        public int coinCount;

        public TMP_Text totalBombs;
        public int bombsCount;

        private void OnEnable()
        {
            CollectableCoin.OnCoinCollected += AddCoin;
            CollectableBombs.OnBombCollected += AddBombs;
        }

        private void OnDisable()
        {
            CollectableCoin.OnCoinCollected -= AddCoin;
            CollectableBombs.OnBombCollected -= AddBombs;
        }

        public void AddCoin()
        {
            GameManager.Instance.totalCoins++;
        }

        public void AddBombs()
        {
            GameManager.Instance.totalBombs++;
        }

        public void Update()
        {
            coinCount = GameManager.Instance.totalCoins;
            totalCoins.text = " " + coinCount + "x";

            bombsCount = GameManager.Instance.totalBombs;
            totalBombs.text = " " + bombsCount + "x";
        }
    }
}

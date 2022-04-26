using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace WarriorOrigins
{
    public class Collectables : MonoBehaviour
    {
        public GameObject Coins;
        public TMP_Text totalCoins;
        public int coinCount;

        private void OnEnable()
        {
            CollectableCoin.OnCoinCollected += AddCoin;
        }

        private void OnDisable()
        {
            CollectableCoin.OnCoinCollected -= AddCoin;
        }

        public void AddCoin()
        {
            coinCount++;
            totalCoins.text = " "+coinCount+"x";
            GameManager.Instance.totalCoins = coinCount;
        }
    }
}

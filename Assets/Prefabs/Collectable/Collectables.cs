using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace WarriorOrigins
{
    public class Collectables : MonoBehaviour
    {
        //public GameObject Coins;
        public TMP_Text totalCoins;
        public int coinCount;

        //public GameObject Shovels;
        public TMP_Text totalShovels;
        public int shovelsCount;

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
            totalCoins.text = " " + coinCount + "x";
            GameManager.Instance.totalCoins = coinCount;
        }

        public void Update()
        {
            shovelsCount = GameManager.Instance.totalShovels;
            totalShovels.text = " " + shovelsCount + "x";
        }
    }
}

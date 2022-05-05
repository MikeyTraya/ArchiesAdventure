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

        public TMP_Text totalShovels;
        public int shovelsCount;

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
            coinCount++;
            GameManager.Instance.totalCoins = coinCount;
            totalCoins.text = " " + coinCount + "x";
        }

        public void AddBombs()
        {
            bombsCount++;
            GameManager.Instance.totalBombs = bombsCount;
            totalBombs.text = " " + bombsCount + "x";
        }

        public void Update()
        {
            shovelsCount = GameManager.Instance.totalShovels;
            totalShovels.text = " " + shovelsCount + "x";

            totalCoins.text = " " + GameManager.Instance.totalCoins + "x";
            totalBombs.text = " " + GameManager.Instance.totalBombs + "x";

        }
    }
}

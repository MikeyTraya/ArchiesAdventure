using UnityEngine;

namespace WarriorOrigins
{
    public class PowerupGoldUI : MonoBehaviour
    {
        public int powerupNumber;

        public Transform powerupUI;

        private void Update()
        {
            powerupNumber = GameManager.Instance.powerUpGoldID;
            if (GameManager.Instance.powerUp3isCollected)
            {
                powerupUI.transform.GetChild(powerupNumber).gameObject.SetActive(true);
            }
        }
    }
}

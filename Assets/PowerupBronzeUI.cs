using UnityEngine;

namespace WarriorOrigins
{
    public class PowerupBronzeUI : MonoBehaviour
    {
        public int powerupNumber;

        public Transform powerupUI;

        private void Update()
        {
            powerupNumber = GameManager.Instance.powerUpBronzeID;
            if (GameManager.Instance.powerUp1isCollected)
            {
                powerupUI.transform.GetChild(powerupNumber).gameObject.SetActive(true);
            }
        }
    }
}

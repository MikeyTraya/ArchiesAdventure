using UnityEngine;

namespace WarriorOrigins
{
    public class PowerupSilverUI : MonoBehaviour
    {
        public int powerupNumber;

        public Transform powerupUI;

        private void Update()
        {
            powerupNumber = GameManager.Instance.powerUpSilverID;
            if (GameManager.Instance.powerUp2isCollected)
            {
                powerupUI.transform.GetChild(powerupNumber).gameObject.SetActive(true);
            }
        }
    }
}

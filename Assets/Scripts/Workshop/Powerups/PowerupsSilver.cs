using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class PowerupsSilver : MonoBehaviour
    {
        public int powerupNumber;
        public Transform powerupType;

        [System.Obsolete]
        private void Start()
        {
            Random.seed = System.DateTime.Now.Millisecond;
            powerupNumber = Random.Range(0, 4);
            powerupType.transform.GetChild(powerupNumber).gameObject.SetActive(true);
            
        }

        private void Update()
        {
            GameManager.Instance.powerUpSilverID = powerupNumber;
            if (!powerupType.transform.GetChild(powerupNumber).gameObject.activeInHierarchy)
            {
                GameManager.Instance.powerUp2isCollected = true;
            }
        }
    }
}

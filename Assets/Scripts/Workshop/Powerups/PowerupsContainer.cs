using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarriorOrigins
{
    public class PowerupsContainer : MonoBehaviour
    {
        public GameObject powerupContainer;
        public Transform powerupSelector;

        public static bool isSelectingPowerUp;

        private void OnEnable()
        {
            powerupContainer.SetActive(false);
        }

        private void Update()
        {
            if (GameManager.Instance.powerUp1isCollected)
            {
                powerupContainer.SetActive(true);
                powerupSelector.transform.gameObject.SetActive(false);
                isSelectingPowerUp = false;
            }

            if (GameManager.Instance.powerUp2isCollected)
            {
                powerupContainer.SetActive(true);
                powerupSelector.transform.gameObject.SetActive(false);
                isSelectingPowerUp = false;
            }

            if (GameManager.Instance.powerUp3isCollected)
            {
                powerupContainer.SetActive(true);
                powerupSelector.transform.gameObject.SetActive(false);
                isSelectingPowerUp = false;
            }

            if (SceneManager.GetActiveScene().buildIndex == 3 && !GameManager.Instance.powerUp1isCollected)
            {
                powerupSelector.transform.gameObject.SetActive(true);
                powerupSelector.transform.GetChild(1).gameObject.SetActive(true);
                isSelectingPowerUp = true;
            }

            if (SceneManager.GetActiveScene().buildIndex == 4 && !GameManager.Instance.powerUp2isCollected)
            {
                powerupSelector.transform.gameObject.SetActive(true);
                powerupSelector.transform.GetChild(2).gameObject.SetActive(true);
                isSelectingPowerUp = true;
            }

            if (SceneManager.GetActiveScene().buildIndex == 5 && !GameManager.Instance.powerUp3isCollected)
            {
                powerupSelector.transform.gameObject.SetActive(true);
                powerupSelector.transform.GetChild(3).gameObject.SetActive(true);
                isSelectingPowerUp = true;
            }

            
        }

        public void BronzePowerupSelected(int Powerup)
        {
            switch (Powerup)
            {
                case 0:
                    // Increase bullet damage
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpBronzeID = Powerup;
                    GameManager.Instance.rangeDamage = 2;
                    GameManager.Instance.powerUp1isCollected = true;
                    break;
                case 1:
                    // Increase melee damage
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpBronzeID = Powerup;
                    GameManager.Instance.meleeDamage = 3;
                    GameManager.Instance.powerUp1isCollected = true;
                    break;
                case 2:
                    // Increase vision range
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpBronzeID = Powerup;
                    GameManager.Instance.innerVisionRange = new Vector3(5, 5, 0);
                    GameManager.Instance.outerVisionRange = new Vector3(12, 12, 0);
                    GameManager.Instance.powerUp1isCollected = true;
                    break;
                case 3:
                    // Decrease stamina cost
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpBronzeID = Powerup;
                    GameManager.Instance.dodgeStamina = 12;
                    GameManager.Instance.rangeWeaponStaminaCost = 4;
                    GameManager.Instance.meleeWeaponStaminaCost = 12;
                    GameManager.Instance.powerUp1isCollected = true;
                    break;
                default:
                    break;
            }
        }
        public void SilverPowerupSelected(int Powerup)
        {
            switch (Powerup)
            {
                case 0:
                    // Increase bullet damage
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpSilverID = Powerup;
                    GameManager.Instance.rangeDamage = 4;
                    GameManager.Instance.powerUp2isCollected = true;
                    break;
                case 1:
                    // Increase melee damage
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpSilverID = Powerup;
                    GameManager.Instance.meleeDamage = 5;
                    GameManager.Instance.powerUp2isCollected = true;
                    break;
                case 2:
                    // Increase vision range
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpSilverID = Powerup;
                    GameManager.Instance.innerVisionRange = new Vector3(7, 7, 0);
                    GameManager.Instance.outerVisionRange = new Vector3(14, 14, 0);
                    GameManager.Instance.powerUp2isCollected = true;
                    break;
                case 3:
                    // Decrease stamina cost
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpSilverID = Powerup;
                    GameManager.Instance.dodgeStamina = 9;
                    GameManager.Instance.rangeWeaponStaminaCost = 2;
                    GameManager.Instance.meleeWeaponStaminaCost = 9;
                    GameManager.Instance.powerUp2isCollected = true;
                    break;
                default:
                    break;
            }
        }
        public void GoldPowerupSelected(int Powerup)
        {
            switch (Powerup)
            {
                case 0:
                    // Increase bullet damage
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpGoldID = Powerup;
                    GameManager.Instance.rangeDamage = 6;
                    GameManager.Instance.powerUp3isCollected = true;
                    break;
                case 1:
                    // Increase melee damage
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpGoldID = Powerup;
                    GameManager.Instance.meleeDamage = 7;
                    GameManager.Instance.powerUp3isCollected = true;
                    break;
                case 2:
                    // Increase vision range
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpGoldID = Powerup;
                    GameManager.Instance.innerVisionRange = new Vector3(9, 9, 0);
                    GameManager.Instance.outerVisionRange = new Vector3(16, 16, 0);
                    GameManager.Instance.powerUp3isCollected = true;
                    break;
                case 3:
                    // Decrease stamina cost
                    EffectsManager.Instance.Play("Powerup");
                    GameManager.Instance.powerUpGoldID = Powerup;
                    GameManager.Instance.dodgeStamina = 5;
                    GameManager.Instance.rangeWeaponStaminaCost = 1;
                    GameManager.Instance.meleeWeaponStaminaCost = 5;
                    GameManager.Instance.powerUp3isCollected = true;
                    break;
                default:
                    break;
            }
        }
    }
}

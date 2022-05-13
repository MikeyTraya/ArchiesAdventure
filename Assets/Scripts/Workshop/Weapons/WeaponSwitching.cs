using System;
using UnityEngine;

namespace WarriorOrigins
{
    public class WeaponSwitching : MonoBehaviour
    {
        private PlayerMovement playerMovement;

        public int selectedWeapon = 0;

        void Start()
        {
            SelectWeapon();
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }

        void Update()
        {
            if (!playerMovement.canMove)
            {
                return;
            }

            if (DodgeRoll.isRolling)
            {
                return;
            }

            if (!PauseMenu.isPause )
            {
                if (!PowerupsContainer.isSelectingPowerUp)
                {
                    if (!DeathManager.isDead)
                    {
                        int previousSelectedWeapon = selectedWeapon;

                        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                        {
                            if (selectedWeapon >= transform.childCount - 1)
                                selectedWeapon = 0;
                            else
                                selectedWeapon++;
                        }
                        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                        {
                            if (selectedWeapon <= 0)
                                selectedWeapon = transform.childCount - 1;
                            else
                                selectedWeapon--;
                        }

                        if (previousSelectedWeapon != selectedWeapon)
                            SelectWeapon();
                    }
                }
            }
        }

        private void SelectWeapon()
        {
            int i = 0;
            foreach (Transform weapon in transform)
            {
                if (i == selectedWeapon)
                    weapon.gameObject.SetActive(true);
                else
                    weapon.gameObject.SetActive(false);
                i++;
            }
        }
    }
}

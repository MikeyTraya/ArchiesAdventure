using System;
using UnityEngine;

namespace WarriorOrigins
{
    public class WeaponSwitching : MonoBehaviour
    {

        public int selectedWeapon = 0;

        public float switchCooldown = 1f;
        private float actCooldown;

        void Start()
        {
            SelectWeapon();
        }

        void Update()
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

            if (actCooldown <= 0)
            {
                if (previousSelectedWeapon != selectedWeapon)
                    SelectWeapon();
            }
            else
            {
                actCooldown -= Time.fixedDeltaTime;
            }
            
        }

        private void SelectWeapon()
        {
            actCooldown = switchCooldown;
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

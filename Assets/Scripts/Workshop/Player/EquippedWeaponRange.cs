using UnityEngine;

namespace WarriorOrigins
{
    public class EquippedWeaponRange : MonoBehaviour
    {
        public int currentWeapon = 0;

        void Update()
        {
            currentWeapon = GameManager.Instance.currentRangeWeaponEquipped;
            SelectedWeapon();
        }

        void SelectedWeapon()
        {
            int i = 0;
            foreach (Transform weapon in transform)
            {
                if (i == currentWeapon)
                    weapon.gameObject.SetActive(true);
                else
                    weapon.gameObject.SetActive(false);

                i++;
            }
        }
    }
}

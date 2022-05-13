using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class WeaponPickupMelee : MonoBehaviour
    {
        public int WeaponID;

        public void PickupWeapon()
        {
            GameManager.Instance.currentMeleeWeaponEquipped = WeaponID;
            Destroy(gameObject);
        }
    }
}

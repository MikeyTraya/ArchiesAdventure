using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class WeaponPickupRange : MonoBehaviour
    {
        public int WeaponID;

        public void PickupWeapon()
        {
            GameManager.Instance.currentRangeWeaponEquipped = WeaponID;
            StartCoroutine(destroyGameObject());
        }

        IEnumerator destroyGameObject()
        {
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }
}

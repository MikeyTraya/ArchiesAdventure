using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class WeaponPickupMelee : MonoBehaviour
    {
        public int WeaponID;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.NotifyPlayer();
                GameManager.Instance.currentMeleeWeaponEquipped = WeaponID;
                StartCoroutine(destroyGameObject());

            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.DenotifyPlayer();
            }
        }

        IEnumerator destroyGameObject()
        {
            yield return new WaitForSeconds(.5f);
            GameManager.Instance.DenotifyPlayer();

            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class ArrowTrap : MonoBehaviour
    {
        public float attackCooldown;
        public Transform firePoint;
        public GameObject[] arrows;
        public float cooldownTimer;

        private void Update()
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= attackCooldown)
            {
                Attack();
            }
        }

        private void Attack()
        {
            cooldownTimer = 0;

            arrows[FindArrows()].transform.position = firePoint.position;
            arrows[FindArrows()].GetComponent<TrapProjectiles>().ActivateTrap();

        }

        private int FindArrows()
        {
            for (int i = 0; i < arrows.Length; i++)
            {
                if (!arrows[i].activeInHierarchy)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}

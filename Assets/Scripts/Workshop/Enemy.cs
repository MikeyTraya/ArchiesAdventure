using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class Enemy : MonoBehaviour
    {
        public int health;

        public void TakeDamage(int damage)
        {
            health -= damage;
            Debug.Log("Damage Taken");
        }
    }
}

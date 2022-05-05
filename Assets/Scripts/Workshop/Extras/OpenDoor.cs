using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class OpenDoor : MonoBehaviour
    {
        public int durability;

        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Bombs"))
            {
                return;
            }

            if (collision.gameObject.CompareTag("Bombs"))
            {
                durability--;
                if (durability <= 0)
                {
                    Break();
                }
            }
        }

        private void Break()
        {
            Destroy(gameObject);
        }




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class EnemyShroomAttack : MonoBehaviour
    {
        [Header("Bullet Settings")]
        public int numberOfBullets;
        public float bulletSpeed;
        public GameObject bullets;

        [Header("Private Variables")]
        private Vector3 startPoint;
        private const float radius = 1f;

        public float burstCooldown;
        private float nextCooldown;

        private void Update()
        {
            if (nextCooldown <= 0)
            {
                startPoint = transform.position;
                Shooting(numberOfBullets);
            }
            else
            {
                nextCooldown -= Time.deltaTime;
            }
        }

        void Shooting(int numberOfBullets)
        {
            nextCooldown = burstCooldown;
            float angleStep = 360f / numberOfBullets;
            float angle = 0f;

            for (int i = 0; i <= numberOfBullets -1; i++)
            {
                float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
                Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * bulletSpeed;

                GameObject tmpObj = Instantiate(bullets, startPoint, Quaternion.identity);
                tmpObj.GetComponent<Rigidbody2D>().AddForce(new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0), ForceMode2D.Impulse);

                angle += angleStep;
            }
        }
    }
}

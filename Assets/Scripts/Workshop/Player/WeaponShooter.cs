using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class WeaponShooter : MonoBehaviour
    {
        public Transform bulletHolder;

        public GameObject bulletPrefab;

        public GameObject muzzleFX;

        public float bulletForce = 20f;

        public float shootCooldown = 6f;
        private float actCooldown;

        // Update is called once per frame
        void Update()
        {
            if (!PauseMenu.isPause)
            {
                if (actCooldown <= 0 && StaminaBar.Instance.currentStamina > 5)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        Shoot();
                    }
                }
                else
                {
                    actCooldown -= Time.deltaTime;
                }
            }
        }

        void Shoot()
        {
            StaminaBar.Instance.UseStamina(5);
            actCooldown = shootCooldown;
            GameObject bullet = Instantiate(bulletPrefab, bulletHolder.position, bulletHolder.rotation);
            GameObject bulletFX = Instantiate(muzzleFX, bulletHolder.position, bulletHolder.rotation);
            
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletHolder.right * bulletForce, ForceMode2D.Impulse);
            Destroy(bulletFX, 0.05f);
        }
    }
}

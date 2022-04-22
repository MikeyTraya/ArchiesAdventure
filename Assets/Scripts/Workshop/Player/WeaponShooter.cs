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

        //Reloading
        public int maxAmmo = 10;
        private int currentAmmo;
        private int lastAmmo;
        public float reloadTime = 1f;
        bool isReloading = false;

        private void Start()
        {
            currentAmmo = maxAmmo;
        }

        private void OnEnable()
        {
            isReloading = false;
            currentAmmo = lastAmmo;
        }

        private void OnDisable()
        {
            lastAmmo = currentAmmo;
        }

        // Update is called once per frame
        void Update()
        {
            if (isReloading)
                return;

            if (currentAmmo <= 0 && StaminaBar.Instance.currentStamina > 50)
            {
                StartCoroutine(Reload());
                return;
            }

            if (actCooldown <= 0)
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

        IEnumerator Reload()
        {
            isReloading = true;
            
            yield return new WaitForSeconds(reloadTime);
            StaminaBar.Instance.UseStamina(50);
            currentAmmo = maxAmmo;
            isReloading = false;
        }

        void Shoot()
        {
            currentAmmo--;
            actCooldown = shootCooldown;
            GameObject bullet = Instantiate(bulletPrefab, bulletHolder.position, bulletHolder.rotation);
            GameObject bulletFX = Instantiate(muzzleFX, bulletHolder.position, bulletHolder.rotation);
            
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletHolder.right * bulletForce, ForceMode2D.Impulse);
            Destroy(bulletFX, 0.05f);
        }
    }
}

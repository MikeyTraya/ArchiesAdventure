using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class WeaponShooter : MonoBehaviour
    {
        public enum State
        {
            Normal,
            Shotgun,
        }

        public State state;

        public Transform bulletHolder;
        public GameObject bulletPrefab;
        public GameObject muzzleFX;
        public float bulletForce = 20f;
        public float shootCooldown = 6f;
        private float actCooldown;

        public int staminaCost;

        private PlayerMovement playerMovement;

        private void Start()
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }

        void Update()
        {
            if (!playerMovement.canMove)
            {
                return;
            }

            staminaCost = GameManager.Instance.rangeWeaponStaminaCost;

            if (!PauseMenu.isPause)
            {
                if (actCooldown <= 0 && StaminaBar.Instance.currentStamina > staminaCost)
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
            switch (state)
            {
                case State.Normal:
                    StaminaBar.Instance.UseStamina(staminaCost);
                    actCooldown = shootCooldown;
                    GameObject bullet = Instantiate(bulletPrefab, bulletHolder.position, bulletHolder.rotation);
                    GameObject bulletFX = Instantiate(muzzleFX, bulletHolder.position, bulletHolder.rotation);

                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(bulletHolder.right * bulletForce, ForceMode2D.Impulse);
                    Destroy(bulletFX, 0.05f);
                    break;

                case State.Shotgun:
                    StaminaBar.Instance.UseStamina(staminaCost);
                    actCooldown = shootCooldown;
                    GameObject bulletFXS = Instantiate(muzzleFX, bulletHolder.position, bulletHolder.rotation);

                    for (int i = 0; i <= 3; i++)
                    {
                        GameObject bulletS = Instantiate(bulletPrefab, bulletHolder.position, bulletHolder.rotation);

                        switch (i)
                        {
                            case 0:
                                Rigidbody2D rbS1 = bulletS.GetComponent<Rigidbody2D>();
                                rbS1.AddForce(bulletHolder.right * bulletForce + new Vector3(0f, Random.Range(-10f, 0f), 0), ForceMode2D.Impulse); 
                                Destroy(bulletFXS, 0.05f);
                                break;
                            case 1:
                                Rigidbody2D rbS2 = bulletS.GetComponent<Rigidbody2D>();
                                rbS2.AddForce(bulletHolder.right * bulletForce + new Vector3(0f, 0f, 0), ForceMode2D.Impulse);
                                Destroy(bulletFXS, 0.05f);
                                break;
                            case 2:
                                Rigidbody2D rbS3 = bulletS.GetComponent<Rigidbody2D>();
                                rbS3.AddForce(bulletHolder.right * bulletForce + new Vector3(0f, Random.Range(0f, 10f), 0), ForceMode2D.Impulse);
                                Destroy(bulletFXS, 0.05f);
                                break;
                            case 3:
                                Rigidbody2D rbS4 = bulletS.GetComponent<Rigidbody2D>();
                                rbS4.AddForce(bulletHolder.right * bulletForce + new Vector3(0f, Random.Range(-10f, 10f), 0), ForceMode2D.Impulse);
                                Destroy(bulletFXS, 0.05f);
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }
            
        }
    }
}

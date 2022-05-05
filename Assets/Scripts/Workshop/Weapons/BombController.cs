using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class BombController : MonoBehaviour
    {
        public GameObject bombs;
        public Vector2 groundDispenseVelocity;
        public Vector2 verticalDispenseVelocity;

        private void Update()
        {
            ThrowBomb();
        }

        void ThrowBomb()
        {
            if (GameManager.Instance.totalBombs == 0)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(bombs, transform.position, Quaternion.identity);
                //GameObject spawnedBomb = Instantiate(bombs, transform.position, Quaternion.identity);
                /*spawnedBomb.GetComponent<FakeHeightProjectiles>().InitializeBomb(
                    transform.right * Random.Range(groundDispenseVelocity.x, groundDispenseVelocity.y),
                    Random.Range(verticalDispenseVelocity.x, verticalDispenseVelocity.y));*/

                GameManager.Instance.BombsUse();
            }
        }
    }
}

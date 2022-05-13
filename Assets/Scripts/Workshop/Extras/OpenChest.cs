using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class OpenChest : MonoBehaviour
    {
        public bool isOpen;

        public Animator animator;

        public GameObject[] loots;

        private int randomNumber;

        private void Start()
        {
            randomNumber = Random.Range(0, loots.Length);
        }

        public void GetLoot()
        {
            if (!isOpen)
            {
                isOpen = true;
                animator.SetBool("isOpen", isOpen);
                StartCoroutine(ClaimableLoot());
            }
        }

        IEnumerator ClaimableLoot()
        {
            yield return new WaitForSeconds(0.6f);
            Instantiate(loots[randomNumber], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

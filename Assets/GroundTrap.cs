using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class GroundTrap : MonoBehaviour
    {
        public int damage = 1;
        public Animator animator;

        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            animator.SetBool("isSomethingHere", true);
            GameManager.Instance.TakeDamage(damage);
            StartCoroutine(TrapClosing());
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            StartCoroutine(TrapClosing());
        }

        IEnumerator TrapClosing()
        {
            yield return new WaitForSeconds(.6f);
            animator.SetBool("isSomethingHere", false);
        }
    }
}

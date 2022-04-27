using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class OpenChest : MonoBehaviour
    {
        public bool isOpen;

        public Animator animator;

        public void GetLoot()
        {
            if (!isOpen)
            {
                isOpen = true;
                GameManager.Instance.ShovelAdd();
                animator.SetBool("isOpen", isOpen);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class OpenDoor : MonoBehaviour
    {
        public void Open()
        {
            if (GameManager.Instance.totalShovels <= 0)
            {
                Debug.Log("No shovels detected");
            }
            else
            {
                GameManager.Instance.ShovelUse();
                Destroy(gameObject);
            }
        }
    }
}

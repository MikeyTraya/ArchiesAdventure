using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class CameraFollowTutorial : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        void Update()
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
        }
    }
}

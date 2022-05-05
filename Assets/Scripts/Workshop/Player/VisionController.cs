using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class VisionController : MonoBehaviour
    {
        public Transform vision;
        public Vector3 innerVisionRange;
        public Vector3 outerVisionRange;

        private void Update()
        {
            innerVisionRange = GameManager.Instance.innerVisionRange;
            outerVisionRange = GameManager.Instance.outerVisionRange;

            vision.transform.GetChild(0).localScale = innerVisionRange;
            vision.transform.GetChild(1).localScale = outerVisionRange;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private Transform destination;

        public Transform GetDestination()
        {
            return destination;
        }
    }
}

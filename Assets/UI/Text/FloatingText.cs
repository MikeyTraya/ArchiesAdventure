using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class FloatingText : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, .5f);
            transform.localPosition += new Vector3(0, 0.5f, 0);
        }
    }
}

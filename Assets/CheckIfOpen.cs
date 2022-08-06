using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class CheckIfOpen : MonoBehaviour
    {
        public GameObject LevelNameHolder;

        private void OnDisable()
        {
            LevelNameHolder.SetActive(true);
        }
    }
}

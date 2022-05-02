using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace WarriorOrigins
{
    public class WeaponStaminaUpdaterMelee : MonoBehaviour
    {
        public TextMeshProUGUI tmPro;
        private void Update()
        {
            tmPro.text = GameManager.Instance.meleeWeaponStaminaCost.ToString();
        }
    }
}

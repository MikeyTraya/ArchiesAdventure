using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WarriorOrigins
{
    public class StaminaBar : MonoBehaviour
    {

        public Slider staminaBar;

        private int maxStamina = 100;
        public int currentStamina;

        private WaitForSeconds regenTick = new WaitForSeconds(0.01f);
        private Coroutine regen;

        public static StaminaBar Instance;
        void Awake() => Instance = this;

        private void Start()
        {
            currentStamina = maxStamina;
            staminaBar.maxValue = maxStamina;
            staminaBar.value = maxStamina;
        }

        public void UseStamina(int amount)
        {
            if(currentStamina - amount >= 0)
            {
                currentStamina -= amount;
                staminaBar.value = currentStamina;

                if (regen != null)
                    StopCoroutine(regen);
                

                regen = StartCoroutine(RegenStamina());
            }
            else
            {
                Debug.Log("Not enough stamina");
            }
        }

        private IEnumerator RegenStamina()
        {
            yield return new WaitForSeconds(1f);

            while(currentStamina < maxStamina)
            {
                currentStamina += maxStamina / 100;
                staminaBar.value = currentStamina;
                yield return regenTick;
            }
            regen = null;
        }
    }
}

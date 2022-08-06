using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WarriorOrigins
{
    public class EffectsVolumeSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        void Awake()
        {
            EffectsManager.Instance.ChangeMasterVolume(slider.value);
            slider.onValueChanged.AddListener(val => EffectsManager.Instance.ChangeMasterVolume(val));
        }
    }
}

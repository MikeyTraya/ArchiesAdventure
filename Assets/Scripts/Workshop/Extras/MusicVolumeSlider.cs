using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WarriorOrigins
{
    public class MusicVolumeSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        void Awake()
        {
            MusicManager.Instance.ChangeMasterVolume(slider.value);
            slider.onValueChanged.AddListener(val => MusicManager.Instance.ChangeMasterVolume(val));
        }
    }
}

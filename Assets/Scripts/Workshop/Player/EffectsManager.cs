using UnityEngine.Audio;
using System;
using UnityEngine;

namespace WarriorOrigins
{
    public class EffectsManager : MonoBehaviour
    {
        public SoundController[] sounds;

        public static EffectsManager Instance;
        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            foreach (SoundController s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.loop = s.loop;
                s.source.pitch = s.pitch;
                s.source.spatialBlend = s.spatialBlend;
            }
        }

        public void ChangeMasterVolume(float volume)
        {
            foreach (SoundController s in sounds)
            {
                s.source.volume = volume;

            }
        }

        public void Play(string name)
        {
            SoundController s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }

        
    }
}

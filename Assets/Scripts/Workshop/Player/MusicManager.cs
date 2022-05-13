using UnityEngine.Audio;
using System;
using UnityEngine;

namespace WarriorOrigins
{
    public class MusicManager : MonoBehaviour
    {
        public SoundController[] sounds;

        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;

        public static MusicManager Instance;
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
            }
        }
        private void Update()
        {
            foreach (SoundController s in sounds)
            {
                s.source.volume = volume;
                s.source.pitch = pitch;
            }
        }

        public void Play(string name)
        {
            SoundController s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }

        public void Stop(string name)
        {
            SoundController s = Array.Find(sounds, sound => sound.name == name);
            s.source.Stop();
        }
    }
}

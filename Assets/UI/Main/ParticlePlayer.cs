using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class ParticlePlayer : MonoBehaviour
    {
        bool startGame;

        private ParticleSystem particle;

        private void Awake()
        {
            particle = GetComponentInChildren<ParticleSystem>();
        }

        public void Update()
        {
            startGame = Input.GetKeyDown(KeyCode.Space);
            if (startGame)
            {
                Invoke("PlayParticle", 2.4f);
            }
        }

        public void PlayParticle()
        {
            particle.Play();
            MenuUI.Instance.Open();
        }
    }
}

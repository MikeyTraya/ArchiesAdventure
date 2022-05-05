using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class DebrisDispenser : MonoBehaviour
    {
        private ParticleSystem particle;

        private void Awake()
        {
            particle = GetComponentInChildren<ParticleSystem>();
        }


        public GameObject debrisParticles;
        public GameObject debrisMark;

        public float damage = 1f;
        public float splashRange = 1f;

        public void DispenseDebris()
        {
            if (splashRange > 0)
            {
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRange);
                foreach (var hitCollider in hitColliders)
                {
                    var enemy = hitCollider.GetComponent<EnemyHealth>();
                    var objects = hitCollider.GetComponent<BreakableObjects>();
                    if (enemy || objects)
                    {
                        var closestPoint = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPoint, transform.position);

                        var damagePercent = Mathf.InverseLerp(splashRange, 0, distance);

                        enemy.TakeDamage((int)damage);
                    }

                }
            }
        }
    }
}

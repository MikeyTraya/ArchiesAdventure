using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace WarriorOrigins
{
    public class SpawnPlayer : MonoBehaviour
    {
        public CinemachineVirtualCamera myCinemachine;

        public GameObject player;
        void Start()
        {
            myCinemachine = GetComponent<CinemachineVirtualCamera>();

            var playerToFollow = Instantiate(player, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity, transform);

            myCinemachine.m_Follow = playerToFollow.transform;
        }
    }
}

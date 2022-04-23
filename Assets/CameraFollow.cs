using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class CameraFollow : MonoBehaviour
    {
        void Update()
        {
            transform.position = new Vector3(LevelGenerator.Instance.player.transform.position.x, LevelGenerator.Instance.player.transform.position.y, 0);
        }
    }
}

using UnityEngine;
using Cinemachine;

namespace WarriorOrigins
{
    public class LevelGenerator : MonoBehaviour
    {
        public Texture2D[] map;
        public Texture2D[] spawnable;

        public int randomNumber;

        public ColorToTile[] colorMappings;

        public ColorToPrefab[] colorSpawnObjects;

        public ColorToPrefab[] colorSpawnPlayer;

        public ColorToPrefab[] colorSpawnTeleporter;

        public CinemachineVirtualCamera myCinemachine;

        public GameObject player;

        public static LevelGenerator Instance;

        void Awake() => Instance = this;

        void Start()
        {
            randomNumber = Random.Range(0, map.Length);
            GenerateLevel();
        }

        void GenerateLevel()
        {
            for (int x = 0; x < map[randomNumber].width; x++)
            {
                for (int y = 0; y < map[randomNumber].height; y++)
                {
                    GenerateTile(x, y);
                }
            }
        }

        void GenerateTile(int x, int y)
        {
            Color pixelColor = map[randomNumber].GetPixel(x, y);

            Color spawnColor = spawnable[randomNumber].GetPixel(x, y);

            if (pixelColor.a == 0 && spawnColor.a == 0)
            {
                return;
            }

            foreach (ColorToTile colorMapping in colorMappings)
            {
                if (colorMapping.color.Equals(pixelColor))
                {
                    colorMapping.tileMap.SetTile(new Vector3Int(x, y, 0), colorMapping.tile);
                }
            }

            foreach (ColorToPrefab colorSpawnObject in colorSpawnObjects)
            {
                if (colorSpawnObject.color.Equals(spawnColor))
                {
                    Instantiate(colorSpawnObject.prefab, new Vector3(x + .5f, y + .5f, 0), Quaternion.identity, transform);
                }
            }

            foreach (ColorToPrefab colorSpawner in colorSpawnPlayer)
            {
                if (colorSpawner.color.Equals(spawnColor))
                {
                    player = Instantiate(colorSpawner.prefab, new Vector3(x + .5f, y + .5f, 0), Quaternion.identity, transform);
                    myCinemachine.m_Follow = player.transform;
                }
            }
        }
    }
}

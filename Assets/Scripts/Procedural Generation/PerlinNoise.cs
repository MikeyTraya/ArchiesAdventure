using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class PerlinNoise : MonoBehaviour
    {
        public Sprite tile;
        public int worldSize;
        public float noiseFrequency = 0.05f;
        public float seed;
        public Texture2D perlinNoiseTexture;

        private void Start()
        {
            seed = Random.Range(-10000, 10000);
            GenerateNoiseTexture();
            GenerateCave();
        }

        private void GenerateCave()
        {
            for (int x = 0; x < worldSize; x++)
            {
                for (int y = 0; y < worldSize; y++)
                {
                    if (perlinNoiseTexture.GetPixel(x, y).r < 0.5f)
                    {
                        GameObject newTile = new GameObject(name = "tile");
                        newTile.transform.parent = this.transform;
                        newTile.AddComponent<SpriteRenderer>();
                        newTile.GetComponent<SpriteRenderer>().sprite = tile;
                        newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);
                    }
                }
            }
        }

        private void GenerateNoiseTexture()
        {
            perlinNoiseTexture = new Texture2D(worldSize, worldSize);

            for (int x = 0; x < perlinNoiseTexture.width; x++)
            {
                for (int y = 0; y < perlinNoiseTexture.height; y++)
                {
                    float v = Mathf.PerlinNoise((x + seed) * noiseFrequency, (y + seed) * noiseFrequency);
                    perlinNoiseTexture.SetPixel(x, y, new Color(v, v, v));
                }
            }

            perlinNoiseTexture.Apply();
        }
    }
}

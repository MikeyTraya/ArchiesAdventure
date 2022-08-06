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
        public float noiseThickness = 0.8f;
        public float borderThickness = 0.23f;

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
                    if (perlinNoiseTexture.GetPixel(x, y).r < noiseThickness)
                    {
                        GameObject newTile = new GameObject(name = "tile");
                        newTile.transform.parent = this.transform;
                        newTile.AddComponent<SpriteRenderer>();
                        newTile.GetComponent<SpriteRenderer>().sprite = tile;
                        newTile.GetComponent<SpriteRenderer>().color = Color.white;
                        newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);
                    }
                    else if (perlinNoiseTexture.GetPixel(x, y).r < noiseThickness + borderThickness)
                    {
                        GameObject newTile = new GameObject(name = "border");
                        newTile.transform.parent = this.transform;
                        newTile.AddComponent<SpriteRenderer>();
                        newTile.GetComponent<SpriteRenderer>().sprite = tile;
                        newTile.GetComponent<SpriteRenderer>().color = Color.black;
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
                    float v = Texture(x, y, seed, noiseFrequency);
                    perlinNoiseTexture.SetPixel(x, y, new Color(v,v,v));
                }
            }

            perlinNoiseTexture.Apply();
        }

        private float Texture(int x, int y, float seed, float noiseFrequency)
        {
            float v = Mathf.PerlinNoise((x + seed) * noiseFrequency, (y + seed) * noiseFrequency);
            return v;
        }
    }
}

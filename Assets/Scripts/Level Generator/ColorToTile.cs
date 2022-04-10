using UnityEngine;
using UnityEngine.Tilemaps;

namespace WarriorOrigins
{
    [System.Serializable]
    public class ColorToTile
    {
        public Color color;
        public Tilemap tileMap;
        public RuleTile tile;
    }
}

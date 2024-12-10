using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GridHandler
{
    public class TileInfo
    {
        private Tilemap _tilemap;

        public TileInfo(Tilemap tilemap) 
        {
            this._tilemap = tilemap;
        }
        public string GetTileTextureName(Vector3 worldPosition)
        {
            Vector3Int gridPosition = _tilemap.WorldToCell(worldPosition);
            TileBase tile = _tilemap.GetTile(gridPosition);

            if (tile is Tile)
            {
                Sprite sprite = ((Tile)tile).sprite;

                if (sprite != null)
                {
                    return sprite.texture.name;
                }
            }
            else if (tile != null)
            {
                return tile.name;
            }

            return "none";
        }
    }
}
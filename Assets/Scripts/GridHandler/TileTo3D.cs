using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GridHandler 
{
    public class TileTo3D : MonoBehaviour
    {
        public GameObject[] tilePrefabs;
        private Dictionary<string, GameObject> tilePrefabsMap = new Dictionary<string, GameObject>();
        private Tilemap tilemap;
        private TileInfo tileInfo;


        void Start()
        {
            tilemap = GetComponent<Tilemap>();
            tileInfo = new TileInfo(tilemap);
            
            MapTiles();
        }

        private void MapTiles()
        {
            foreach (var prefab in tilePrefabs)
            {
                if (prefab == null) continue;

                if (tilePrefabsMap.ContainsKey(prefab.name) == false)
                {
                    tilePrefabsMap.Add(prefab.name, prefab);
                }
            }
        }

        public void Create3DTilemap(GameObject parent = null)
        {
            foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
            {
                if (!tilemap.HasTile(position)) continue;

                string Tile2DName = ((Tile)tilemap.GetTile(position)).sprite.texture.name;

                GameObject tmpTile = tilePrefabsMap[Tile2DName];
                Vector3 worldPos = tilemap.CellToWorld(position);
                if (tmpTile == null)
                {
                    tmpTile = GameObject.CreatePrimitive(PrimitiveType.Cube);
                }

                tmpTile.transform.position = worldPos;
                tmpTile.transform.rotation = Quaternion.identity;

                if (parent == null)
                {
                    Instantiate(tmpTile);
                }
                else
                {
                    Instantiate(tmpTile, parent.transform);
                }
            }
            tilemap.gameObject.SetActive(false);
        }
    }
}

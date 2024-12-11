using NSubstitute.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GridHandler 
{
    [ExecuteInEditMode]
    public class TileTo3D : MonoBehaviour
    {
        public GameObject[] tilePrefabs;
        private Dictionary<string, GameObject> tilePrefabsMap = new Dictionary<string, GameObject>();
        private Tilemap tilemap;
        private TileInfo tileInfo;


        void Start()
        {
            tileInfo = new TileInfo(tilemap);
        }

        public void MapTiles(Tilemap tilemap)
        {
            this.tilemap = tilemap;

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
            Clear3DTilemap(parent);

            float offsetX = 0f; 
            float offsetZ = 0f;

            BoundsInt bounds = tilemap.cellBounds;

            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {

                    Vector3Int position = new Vector3Int(x, y, 0);
                    string Tile2DName = ((Tile)tilemap.GetTile(position)).sprite.texture.name;

                    GameObject tmpTile = tilePrefabsMap[Tile2DName];
                    if (tmpTile == null)
                    {
                        tmpTile = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }

                    Debug.Log(parent.name);

                    GameObject instantiatedTile = (parent == null)
                        ? Instantiate(tmpTile)
                        : Instantiate(tmpTile, parent.transform);

                    Renderer renderer = instantiatedTile.GetComponent<Renderer>();
                    if (renderer == null) continue;

                    Vector3 tileSize = renderer.bounds.size;

                    instantiatedTile.transform.position = new Vector3(offsetX, 0, offsetZ);
                    instantiatedTile.transform.rotation = Quaternion.identity;

                    offsetX += tileSize.x;

                    if (y == bounds.yMax - 1) {
                        offsetZ += tileSize.z;
                    }
                }
                offsetX = 0f;
            }
            tilemap.gameObject.SetActive(false);
        }

        public void Clear3DTilemap(GameObject parent)
        {
            foreach (Transform child in parent.transform)
            {
                Debug.Log(child.name);
                Destroy(child.gameObject);
            }
        }
    }
}

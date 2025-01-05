using UnityEngine;
using System.Collections.Generic;

public class InfiniteMap : SpawnerTemplate
{
    [SerializeField] protected float chunkSize =200f * 0.15f;
    [SerializeField] List<Transform> mapChunks;
    protected override void Reset()
    {
        base.Reset();
        this.GenerateMap();
    }
    protected virtual void GenerateMap()
    {
        if (mapChunks.Count > 9) return;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1 ; y++)
            {
                GenerateMapChunk(x, y);
            }
        }
    }
    protected virtual void GenerateMapChunk(int x, int y)
    {
        Vector3 position = new Vector2(x, y) * chunkSize;
        Transform chunk = this.GetPrefabAtFirst();
        if (chunk != null)
        {
            Transform prefab = this.Spawn(chunk, position, Quaternion.identity);
            prefab.gameObject.SetActive(true);

            mapChunks.Add(prefab);
        }

    }
}

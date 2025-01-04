using UnityEngine;

public class Spawner : SpawnerCtrl
{
    // control spawn amount
    [SerializeField] protected int spawnedCount = 0;
    protected Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(position, rotation);
        newPrefab.SetParent(this.holder);

        spawnedCount++;
        return newPrefab;

    }

    // get transform of prefabs
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        // check in pool
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj == null) continue;

            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        // if pool is null
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }


    // get type of prefabs we need to spawn
    protected virtual Transform GetPrefabsByName(string name)
    {

        // check in prefabs
        foreach (Transform t in prefabs)
        {
            if (t.name == name)
            {
                return t;
            }
        }
        // this spawner can't spawn
        return null;
    }
    public virtual void OnDespawn(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;

        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }
}

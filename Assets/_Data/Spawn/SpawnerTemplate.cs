using System.Collections.Generic;
using UnityEngine;

public class SpawnerTemplate: MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;

    // can use queue
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;

    protected virtual void Reset()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabsTf = transform.Find("prefabs");
        foreach (Transform t in prefabsTf)
        {
            prefabs.Add(t);
            t.gameObject.SetActive(false);
        }
        Debug.Log(transform.name + ": Load prefabs ", gameObject);
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("holder");
       
        Debug.Log(transform.name + ": Load holder ", gameObject);
    }
    protected virtual Transform GetPrefabAtFirst()
    {
        if (this.prefabs.Count > 0)
        {
            return this.prefabs[0];
        }
        return null;
    }
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
    protected Transform Spawn(Vector3 position, Quaternion rotation)
    {
        return this.Spawn( GetPrefabAtFirst(), position, rotation);
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
    //protected virtual void ClearPool()
    //{
    //    foreach (Transform poolObj in this.poolObjs)
    //    {
    //        if (poolObj == null) continue;
    //        this.poolObjs.Remove(poolObj);    
    //    }
    //}
}

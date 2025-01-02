using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MyMonoBehaviour
{
    [SerializeField] protected Transform holder;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder " + gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;


        Transform list = transform.Find("Prefabs");
        prefabs = new List<Transform>();
        foreach (Transform item in list)
        {
            this.prefabs.Add(item);
        }

        this.HidePrefabs();

        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }


    public virtual Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot)
    {
        Transform newPrefabs = this.GetObjFromPoll(prefab);
        newPrefabs.SetPositionAndRotation(pos, rot);
        newPrefabs.SetParent(holder);

        spawnedCount++;
        return newPrefabs;
    }
    public virtual void Despawn(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;

        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }
    protected virtual Transform GetObjFromPoll(Transform prefab)
    {
        foreach (var poolObj  in this.poolObjs)
        {
            if (poolObj == null) continue;

            if(poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }

    public virtual Transform FirstPrefab()
    { 
        if (this.prefabs.Count == 0) return null;   
        return this.prefabs[0];
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
    public virtual void Hold(Transform obj)
    {
        obj.parent = this.holder;
    }
}

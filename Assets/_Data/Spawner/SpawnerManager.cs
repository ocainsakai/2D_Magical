using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] protected static SpawnerManager instance;
    public static SpawnerManager Instance => instance;


    [SerializeField] protected List<SpawnerBase> spawners;

    protected void Reset()
    {
        if (instance != null)
        {
            Debug.LogError("Only 1 Instance SpawnerManager");
        }
        instance = this;
    }
    public void RegisterSpawner(SpawnerBase spawner)
    {
        if (!spawners.Contains(spawner))
        {
            spawners.Add(spawner);
        }
    }

    public void UnregisterSpawner(SpawnerBase spawner)
    {
        if (spawners.Contains(spawner))
        {
            spawners.Remove(spawner);
        }
    }

}

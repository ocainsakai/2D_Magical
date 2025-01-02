using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MyMonoBehaviour
{
    [SerializeField] protected List<Transform> spawnPoints;
    public List<Transform> SpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadSpawnPoint()
    {
        foreach (Transform point in this.transform)
        {
            spawnPoints.Add(point);
        }
        Debug.LogWarning(transform.name + ": LoadSpawnPoint " + gameObject);
    }
}

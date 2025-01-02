using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MyMonoBehaviour
{
    [SerializeField] protected List<Transform> points;
    public List<Transform> Points => points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadSpawnPoints()
    {
        foreach (Transform point in this.transform)
        {
            points.Add(point);
        }
        Debug.LogWarning(transform.name + ": LoadSpawnPoint " + gameObject);
    }
    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }
}

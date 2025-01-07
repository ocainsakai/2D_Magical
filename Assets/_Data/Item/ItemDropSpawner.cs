using UnityEngine;

public class ItemDropSpawner : SpawnerBase
{
    [SerializeField] protected static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;
    protected void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Only 1 ItemDropSpawner instance");
        }
        instance = this;
    }
    public void DropExp(Vector3 position)
    {
        this.Spawn(position, Quaternion.identity);
    }
}

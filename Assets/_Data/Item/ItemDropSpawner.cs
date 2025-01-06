using UnityEngine;

public class ItemDropSpawner : SpawnerTemplate
{
    [SerializeField] public static ItemDropSpawner Instance { get; private set; }

    protected virtual void Awake()
    {
        if (ItemDropSpawner.Instance != null)
        {
            Debug.Log(" Only have 1 Enemy spawner");
        }
        ItemDropSpawner.Instance = this;
    }

    public void DropExp(Vector3 position)
    {
        this.Spawn(position, Quaternion.identity);
    }
}

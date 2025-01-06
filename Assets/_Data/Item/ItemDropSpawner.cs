using UnityEngine;

public class ItemDropSpawner : SpawnerTemplate
{
    [SerializeField] public static ItemDropSpawner Instancce { get; private set; }

    protected virtual void Awake()
    {
        if (ItemDropSpawner.Instancce != null)
        {
            Debug.Log(" Only have 1 Enemy spawner");
        }
        ItemDropSpawner.Instancce = this;
    }

    public void DropExp(Vector3 position)
    {
        this.Spawn(position, Quaternion.identity);
    }
}

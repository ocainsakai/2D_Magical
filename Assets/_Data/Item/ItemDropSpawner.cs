using UnityEngine;

public class ItemDropSpawner : SpawnerBase
{

    public void DropExp(Vector3 position)
    {
        this.Spawn(position, Quaternion.identity);
    }
}

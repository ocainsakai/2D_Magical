using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public abstract class CtrlBase : LoadPhysicElement
{
    [SerializeField] protected SpawnerBase spawner;
    public SpawnerBase Spawner => spawner;

    public void SetSpawner(SpawnerBase spawner)
    {
        this.spawner = spawner;
    }
    
}

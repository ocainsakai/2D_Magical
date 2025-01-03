using UnityEngine;

public class FXSpawner : Spawner
{

    [SerializeField] protected static FXSpawner _instance;
    public static FXSpawner Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner._instance != null) Debug.LogError("Only 1 FXSpawner allow to exist");
        FXSpawner._instance = this;
    }

    public override void Despawn(Transform obj)
    {
        
    }

}

using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }


    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }

    protected override void Start()
    {
        this.Test();
    }

    protected virtual void Test()
    {
        Transform enemy =  Spawn(prefabs[0], transform.position, Quaternion.identity);
        enemy.gameObject.SetActive(true);
    }
}

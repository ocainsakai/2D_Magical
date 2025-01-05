using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : SpawnerTemplate
{
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected int maxSpawnCount =9;
    [SerializeField] protected float spawnDelay = 2f;
    protected override void Reset()
    {
        base.Reset();
        this.LoadSpawnPoint();
    }

    protected void Awake()
    {
        TestSpawn();
    }
    public void TestSpawn()
    {
        if (spawnCount >= maxSpawnCount) return;

        RandomSpawn();
        Invoke(nameof(TestSpawn), spawnDelay);
    }
    protected virtual void RandomSpawn()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        Vector3 randPoint = spawnPoint.position + new Vector3(x, y , 0);
        Transform newEnemy = this.Spawn(randPoint, Quaternion.identity);
        newEnemy.gameObject.SetActive(true);
    }
    protected virtual void LoadSpawnPoint()
    {
        if (spawnPoint == null)
        {
            this.spawnPoint = GameObject.Find("SceneSpawnPoints").transform;
        }
    }
}

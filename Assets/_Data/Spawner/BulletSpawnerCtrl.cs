using UnityEngine;

public class BulletSpawnerCtrl : SpawnerCtrl
{

    [SerializeField] protected static BulletSpawnerCtrl instance;
    public static BulletSpawnerCtrl Instance => instance;

    protected override void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<BulletSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawner", gameObject);
    }
}

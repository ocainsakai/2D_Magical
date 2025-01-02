using UnityEngine;

public class BulletSpawner : Spawner
{

    [SerializeField] protected static BulletSpawner _instance;
    public static BulletSpawner Instance => _instance;

    //[SerializeField] protected BulletSpawnerCtrl _ctrl;
    //public BulletSpawnerCtrl Ctrl => _ctrl;

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner._instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        BulletSpawner._instance = this;
    }
    //protected override void LoadComponents()
    //{
    //    base.LoadComponents();
    //    this.LoadBulletSpawnerCtrl();
    //}

    //protected virtual void LoadBulletSpawnerCtrl()
    //{
    //    if (this._ctrl != null) return;
    //    this._ctrl = GetComponent<BulletSpawnerCtrl>();
    //    Debug.LogWarning(transform.name + ": LoadBulletSpawnerCtrl", gameObject);
    //}
}

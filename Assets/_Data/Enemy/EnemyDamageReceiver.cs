using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy Dame Receiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl BulletCtrl => enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();

    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.enemyCtrl.Spawner.Despawn(this.transform.parent);
    }

    //can upgrade
    protected virtual void OnDeadFX()
    {
        Vector3 vector = transform.position;    
        Quaternion quaternion = Quaternion.identity;
        Transform newFX =  FXSpawner.Instance.Spawn(FXSpawner.Instance.FirstPrefab(), vector, quaternion);
        newFX.gameObject.SetActive(true);
        newFX.GetComponentInChildren<FXDespawn>().ActiveDespawn();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        //ItemDropSpawner.Instance.Drop(this.enemyCtrl.ShootableObject.dropList, dropPos, dropRot);
    }
}

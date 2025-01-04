using UnityEngine;

public class EnemyDamageReceiver : ShootableObjDameReceiver
{
    [Header("Enemy Dame Receiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

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

}

using UnityEngine;

public class EnemyAbstract : MyMonoBehaviour
{
    [Header("Enemy Abtract")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl BulletCtrl  => enemyCtrl; 

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
}

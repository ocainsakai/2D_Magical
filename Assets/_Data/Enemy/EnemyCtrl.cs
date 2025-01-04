using UnityEngine;

public class EnemyCtrl : ShootableObjCtrl
{
    [SerializeField] protected EnemySpawner _spawner;
    public EnemySpawner EnemySpawner => _spawner;

    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (_spawner != null) return;
        this._spawner = transform.parent?.parent?.GetComponentInChildren<EnemySpawner>();
        Debug.Log(transform.name + ": LoadEnemySpawner", gameObject);

    }
}

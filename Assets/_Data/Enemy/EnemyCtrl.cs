using UnityEngine;

public class EnemyCtrl : MyMonoBehaviour
{
    [SerializeField] protected EnemySpawner _spawner;
    public EnemySpawner Spawner => _spawner;

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

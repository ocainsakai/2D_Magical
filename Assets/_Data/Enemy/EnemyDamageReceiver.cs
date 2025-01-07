using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    protected override void Die()
    {
        this.Ctrl.Spawner.OnDespawn(this.transform.parent);
        this.OnDieDrop();
    }
    protected virtual void OnDieDrop()
    {
        ItemDropSpawner.Instance.DropExp(this.transform.position);
    }
}

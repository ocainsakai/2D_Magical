using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    protected override void Die()
    {
        this.OnDieDrop();
        EnemySpawner.Instancce.OnDespawn(this.transform.parent);
    }
    protected void OnDieDrop()
    {
        ItemDropSpawner.Instance.DropExp(this.transform.position);
    }
}

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
        ItemDropSpawner.Instancce.DropExp(this.transform.position);
    }
}

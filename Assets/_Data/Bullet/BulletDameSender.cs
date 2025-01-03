using UnityEngine;

public class BulletDameSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        Debug.Log(transform.name + ": LoadComponents " + damage, gameObject);

    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
        Debug.Log(transform.name + ": LoadBulletCtrl " + damage, gameObject);
    }

    // find another way to creat link to ctrl

    public override void Send(DamageReceiver damageReceiver)
    {

        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}

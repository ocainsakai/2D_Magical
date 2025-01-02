using UnityEngine;

public class BulletCtrl : MyMonoBehaviour
{
    [SerializeField] protected BulletDameSender _damageSender;
    public BulletDameSender DamageSender => _damageSender;
    [SerializeField] protected BulletDespawn _bulletDespawn;
    public BulletDespawn BulletDespawn => _bulletDespawn;
    [SerializeField] protected Transform shooter;

    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDamageSender()
    {
        if (_damageSender != null) return;
        this._damageSender = transform.GetComponentInChildren<BulletDameSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);

    }

    protected virtual void LoadBulletDespawn()
    {
        if (_bulletDespawn != null) return;
        this._bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);

    }
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }



}

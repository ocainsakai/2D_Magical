using UnityEngine;
[RequireComponent(typeof(SphereCollider))]

public abstract class DamageReceiver : MyMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider _sphereCollider;
    [SerializeField] protected double hp = 1;
    [SerializeField] protected double hpMax = 2;
    [SerializeField] protected bool isDead = false;
    public bool IsDead => this.HP <= 0;
    public double HP => hp;
    public double HPMax => hpMax;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (_sphereCollider != null) return;
        this._sphereCollider = GetComponent<SphereCollider>();
        this._sphereCollider.isTrigger = false;
        this._sphereCollider.radius = 0.5f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected override void OnEnable()
    {
        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Add(double add)
    {
        if (this.IsDead) return;
        this.hp += add;
        if (this.hp > this.hpMax) this.hpMax = this.hp;

    }
    public virtual void Deduct(double deduct)
    {
        if (this.IsDead) return;
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        CheckIsDead();

    }

    protected void CheckIsDead()
    {
        if (!this.IsDead) return;
        this.isDead = true;
        this.OnDead();
    }
    protected void SetMaxHP(double max)
    {
        this.hpMax = max;
    }
    protected abstract void OnDead();
}

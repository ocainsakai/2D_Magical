using UnityEngine;

public class FXDespawn : DespawnByTime
{
    [SerializeField] protected FXCtrl _FXCtrl;
    public FXCtrl FXCtrl => _FXCtrl;

    //protected float duration => _FXCtrl.ParticleSystem.main.duration;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        Debug.Log(transform.name + ": LoadComponents " , gameObject);

    }
    
    protected virtual void LoadBulletCtrl()
    {
        if (this._FXCtrl != null) return;
        this._FXCtrl = transform.parent.GetComponent<FXCtrl>();
        Debug.Log(transform.name + ": LoadFXCtrl", gameObject);
    }
    public override void ActiveDespawn()
    {
        this.timeDestroy = _FXCtrl.Particle.main.duration + 0.1f;
        base.ActiveDespawn();
    }
    protected override void OnDespawn()
    {
        FXSpawner.Instance.Despawn(this.transform.parent);
    }
    
}

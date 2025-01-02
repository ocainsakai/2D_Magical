using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected SphereCollider _sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadSphereCollider()
    {
        if (_sphereCollider != null) return;
        this._sphereCollider = GetComponent<SphereCollider>();
        this._sphereCollider.isTrigger = true;
        this._sphereCollider.radius = 0.5f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (_rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);

    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        //if (other.transform.parent == this.bulletCtrl.Shooter) return;

        //this.bulletCtrl.DamageSender.Send(other.transform);
        ////this.CreateImpactFX(other);
    }

}

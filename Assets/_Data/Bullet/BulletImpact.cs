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
        this._sphereCollider.radius = 0.25f;
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
        if (other.transform.parent == this.bulletCtrl.Shooter) return;
        this.bulletCtrl.DamageSender.Send(other.transform);
        this.CreateImpactFX(other);
    }


    // can upgrade
    protected virtual void CreateImpactFX(Collider orther)
    {
        Vector3 spawnPos = transform.position;
        Quaternion rot = transform.parent.rotation;

        // to do choice bullet prefab
        Transform newFX = FXSpawner.Instance.Spawn(FXSpawner.Instance.FirstPrefab(), spawnPos, rot);
        newFX.gameObject.SetActive(true);

        newFX.GetComponentInChildren<FXDespawn>().ActiveDespawn();
    }
}

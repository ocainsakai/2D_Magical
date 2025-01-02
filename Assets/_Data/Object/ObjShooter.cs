using UnityEngine;

public abstract class ObjShooter : MyMonoBehaviour
{
    [Header("Obj Shooter")]
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float damage;

    protected void Update()
    {
        this.IsShooting();
    }

    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        shootTimer += Time.fixedDeltaTime;
        //Debug.Log("is shot");

        if (!this.isShooting) return;

        if (shootTimer < shootDelay) return;

        this.shootTimer = 0;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        

        // to do choice bullet prefab
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.FirstPrefab(), spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.DamageSender.SetDamage(this.damage);
        bulletCtrl.SetShooter(transform.parent);
    }
    public virtual void SetDame(float dame)
    {
        this.damage = dame;
    }
    public virtual void SetDelay(float delay)
    {
        this.shootDelay = delay;
    }
    protected abstract bool IsShooting();
}

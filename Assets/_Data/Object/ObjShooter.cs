using UnityEngine;

public abstract class ObjShooter : MyMonoBehaviour
{
    [Header("Obj Shooter")]
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float damage;

    protected virtual void Shoot(Vector3 mousePos)
    {
        if (isShooting) return;
        StartCoroutine(Shooting(mousePos));
    }

    protected virtual System.Collections.IEnumerator Shooting(Vector3 mousePos)
    {
        isShooting = true;

        Vector3 spawnPos = transform.position;

        Vector3 dir = mousePos - transform.parent.position;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.Euler(0f, 0f, rot_z);

        // to do choice bullet prefab
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.FirstPrefab(), spawnPos, rot);
        
        newBullet.gameObject.SetActive(true);
        
        


        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.DamageSender.SetDamage(this.damage);
        bulletCtrl.SetShooter(transform.parent);

        yield return new WaitForSeconds(shootDelay);
        isShooting = false;
    }
    
    public virtual void SetDame(float dame)
    {
        this.damage = dame;
    }
    public virtual void SetDelay(float delay)
    {
        this.shootDelay = delay;
    }
}

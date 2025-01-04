using UnityEngine;

public class ShootableObjDameReceiver : DamageReceiver
{

    [Header("Shootalbe Dame Receiver")]
    [SerializeField] protected ShootableObjCtrl shootableCtrl;
    public ShootableObjCtrl BulletCtrl => shootableCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();

    }
    protected virtual void LoadCtrl()
    {
        if (this.shootableCtrl != null) return;
        this.shootableCtrl = transform.parent.GetComponent<ShootableObjCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.shootableCtrl.Despawn.DespawnObject();
    }

    //can upgrade
    protected virtual void OnDeadFX()
    {
        Vector3 vector = transform.position;
        Quaternion quaternion = Quaternion.identity;
        Transform newFX = FXSpawner.Instance.Spawn(FXSpawner.Instance.FirstPrefab(), vector, quaternion);
        newFX.gameObject.SetActive(true);
        newFX.GetComponentInChildren<FXDespawn>().ActiveDespawn();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableCtrl.ShootableObject.dropList, dropPos, dropRot);
    }
}


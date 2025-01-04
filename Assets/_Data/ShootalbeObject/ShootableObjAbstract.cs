using UnityEngine;

public abstract class ShootableObjAbstract : MyMonoBehaviour
{
    [Header("Shootalbe Abtract")]
    [SerializeField] protected ShootableObjCtrl _shootalbeObjCtrl;
    public ShootableObjCtrl Ctrl => _shootalbeObjCtrl; 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootalbeCtrl();
    }
    protected virtual void LoadShootalbeCtrl()
    {
        if (this._shootalbeObjCtrl != null) return;
        this._shootalbeObjCtrl = transform.parent.GetComponent<ShootableObjCtrl>();
        Debug.LogWarning(transform.name + ": LoadShootalbeCtrl", gameObject);
    }
}

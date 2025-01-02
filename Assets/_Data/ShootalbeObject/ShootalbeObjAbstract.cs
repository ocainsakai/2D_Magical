using UnityEngine;

public abstract class ShootalbeObjAbstract : MyMonoBehaviour
{
    [Header("Shootalbe Abtract")]
    [SerializeField] protected ShootalbeObjCtrl _shootalbeObjCtrl;
    public ShootalbeObjCtrl Ctrl => _shootalbeObjCtrl; 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootalbeCtrl();
    }
    protected virtual void LoadShootalbeCtrl()
    {
        if (this._shootalbeObjCtrl != null) return;
        this._shootalbeObjCtrl = transform.parent.GetComponent<ShootalbeObjCtrl>();
        Debug.LogWarning(transform.name + ": LoadShootalbeCtrl", gameObject);
    }
}

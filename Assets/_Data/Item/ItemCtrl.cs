using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]

public class ItemCtrl : CtrlBase
{
    [SerializeField] private ItemProfile itemProfile;
    public ItemProfile ItemProfile => itemProfile;
    protected override void Reset()
    {
        base.Reset();
        this.SetLayerRecursively(this.gameObject);
        this.LoadItemProfile();
    }
    protected virtual void LoadItemProfile()
    {
        if (itemProfile == null)
        {
            itemProfile = this.GetComponentInChildren<ItemProfile>();
        }
    }
    private void SetLayerRecursively(GameObject obj)
    {

        obj.layer = LayerMask.NameToLayer("Item");
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject);
        }
    }
    // dulicate
}

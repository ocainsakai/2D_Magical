using UnityEngine;
[RequireComponent (typeof(CircleCollider2D))]
public class ItemPickUp : LoadCtrl<PlayerCtrl>
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemCtrl item = collision.GetComponent<ItemCtrl>();
        if (item != null)
        {
            PickUp(item);
        }
    }

    private void PickUp(ItemCtrl item)
    {

        // send item
        if (item.ItemProfile.Type == ItemProfile.ItemType.Exp)
        {
            this.ctrl.Level.AddXP(10);
        }
        // Xóa vật phẩm khỏi scene
        ItemDropSpawner.Instance.OnDespawn(item.transform);
    }
}

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
        if (item.ItemProfile.Type == ItemType.Exp)
        {
            this.Ctrl.Level.AddXP(10);
        }
        // Xóa vật phẩm khỏi scene
        item.Spawner.OnDespawn(item.transform);
    }
}

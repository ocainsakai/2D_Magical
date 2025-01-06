using UnityEngine;

public class ItemProfile : MonoBehaviour
{
    public enum ItemType
    {
        None,
        Mana,
        Health,
        Exp,
        InventoryItem,
    }
    public ItemType Type;   
}

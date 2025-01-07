using UnityEngine;

public class ItemProfile : MonoBehaviour
{
    public ItemType Type;   
}
public enum ItemType
{
    None,
    Mana,
    Health,
    Exp,
    InventoryItem,
}

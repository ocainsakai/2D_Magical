using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    [SerializeField] protected static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null)
            Debug.LogError("Have only 1 ItemDropSpawner");
        ItemDropSpawner.instance = this;
    }

    public virtual List<ItemDropRate> Drop (List<ItemDropRate> dropList, Vector3 pos, Quaternion rot)
    {
        List<ItemDropRate > dropItems = new List<ItemDropRate>();

        if (dropList.Count > 0)
        {
            dropItems = DropItems(dropList);
            foreach (ItemDropRate item in dropItems)
            {
                // can upgrade code
                ItemCode itemCode = item.itemSO.itemCode;
                Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);

                if (itemDrop == null) continue;
                itemDrop.gameObject.SetActive(true);

            }
        }
        
        return dropItems;
    }

    public virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();
        float rate, itemRate;
        int itemDropMore;
        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate / 100000f;
            itemDropMore = Mathf.FloorToInt(itemRate);
            if (itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore; i++)
                {
                    droppedItems.Add(item);
                }
            }


            if (rate <= itemRate)
            {
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

}


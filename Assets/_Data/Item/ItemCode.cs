using System;
using UnityEngine;

public enum ItemCode
{
    NoItem = 0,

    Exp = 1,
    ExpMedium = 2,

    ExpExtra = 100,

    CopperSword = 1000,
}
// can be upgrade
public class ItemCodeParser
{
    public static ItemCode FromString(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
}
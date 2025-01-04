using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]

public class ShootableObjSO : ScriptableObject
{
    public string objName = "Shootable Object";
    public ObjectType objType;
    public double hpMax = 2;
    public List<ItemDropRate> dropList;
}
public enum ObjectType
{
    NoType = 0,

    Junk = 1,
    Enemy = 2,
    Boss = 3,
    Ship = 4,
}
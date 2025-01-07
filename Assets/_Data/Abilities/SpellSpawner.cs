using Unity.Mathematics;
using UnityEngine;

public class SpellSpawner : SpawnerBase
{
    [SerializeField] protected static SpellSpawner instance;
    public static SpellSpawner Instance => instance;
    protected void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Only 1 ItemDropSpawner instance");
        }
        instance = this;
    }

    public virtual void Spawn(string spell)
    {
        Transform pf = GetPrefabsByName(spell);
        Transform newSpell = this.Spawn(pf, this.transform.position, Quaternion.identity);
        newSpell.gameObject.SetActive(true);
    }
}

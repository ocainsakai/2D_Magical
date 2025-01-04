using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl: MyMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabsTf = transform.Find("prefabs");
        foreach (Transform t in prefabsTf)
        {
            prefabs.Add(t);
            t.gameObject.SetActive(false);
        }
        Debug.Log(transform.name + ": Load prefabs ", gameObject);
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("holder");
       
        Debug.Log(transform.name + ": Load holder ", gameObject);
    }
}

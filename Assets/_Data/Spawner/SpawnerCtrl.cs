using UnityEngine;

public class SpawnerCtrl : MyMonoBehaviour
{
    [SerializeField] protected SpawnerCtrl instance;
    public SpawnerCtrl Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
    }

    protected virtual void LoadSpawnerCtrl()
    {
        if (this.instance != null) return;
        this.instance = GetComponent<SpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

}

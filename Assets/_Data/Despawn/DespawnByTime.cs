using Unity.VisualScripting;
using UnityEngine;

public abstract class DespawnByTime : MyMonoBehaviour
{

    [SerializeField] protected float timeDestroy = 3f;
    protected override void ResetValue()
    {
        this.timeDestroy = 3f;
    }
    protected virtual System.Collections.IEnumerator Despawning(float timeDestroy)
    {
        yield return new WaitForSeconds(timeDestroy);
        OnDespawn();
    }
    public virtual void ActiveDespawn()
    {
        StartCoroutine(Despawning(timeDestroy));
    }
    protected abstract void OnDespawn();
}

using Unity.VisualScripting;
using UnityEngine;

public abstract class DespawnByTime : MyMonoBehaviour
{

    [SerializeField] protected float timeDestroy = 70f;

    protected virtual System.Collections.IEnumerator Despawning(float timeDestroy)
    {
        yield return timeDestroy;
        OnDespawn();
    }
    public virtual void ActiveDespawn()
    {
        StartCoroutine(Despawning(timeDestroy));
    }
    protected abstract void OnDespawn();
}

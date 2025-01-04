using System.Collections;
using UnityEngine;

[SerializeField]
public class MoveToTarget<T> : MyMonoBehaviour where T : class
{
    [SerializeField] protected T target;
    public T Target => target;

    protected Vector3 targetPosition;
    public void SetTarget(T target)
    {
        
        if (target is Transform transform)
        {
            this.targetPosition = transform.position;
        }
        else if (target is Vector3 vector3) 
        {
            this.targetPosition = vector3;
        }
        else
        {
            Debug.LogError("Target must be of type Transform or Vector3!");
            return;
        }
        this.target = target;
    }

    public void Move()
    {
        if (target != null) 
         StartCoroutine(Moving(targetPosition));
    }

    protected virtual IEnumerator Moving(Vector3 vectorTarget)
    {
        // Di chuyển đến Vector3
        while (Vector2.Distance(transform.position, vectorTarget) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, vectorTarget, Time.deltaTime);
            yield return null;
        }
    }
}

using UnityEngine;

public abstract class FollowTarget : MyMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField ] protected float speed = 2f;

    
    protected virtual void SetTarget(Transform target)
    {
        this.target = target;
    

    }
   
    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        this.transform.position = Vector2.Lerp(this.transform.position, target.position, Time.fixedDeltaTime * speed);
    }
}

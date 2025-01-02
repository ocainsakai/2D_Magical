using UnityEngine;

public class ObjMovement : MyMonoBehaviour
{
    [Header("Obj Movement")]
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected Vector3 offsetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        Vector3 movePos = this.targetPosition;
        movePos += this.offsetPosition;
        this.distance = Vector3.Distance(movePos, targetPosition);
        if (this.distance < 0) return;
        Vector3 newPOs = Vector3.Lerp(movePos, movePos, this.speed);

        transform.parent.position = newPOs;
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public virtual void SetOffsetPosition(Vector3 newOffset)
    {
        this.offsetPosition = newOffset;
    }
}

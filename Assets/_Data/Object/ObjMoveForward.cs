using UnityEngine;

public class ObjMoveForward : ObjMovement
{
    //[Header("Move Foward")]
    //[SerializeField] protected Transform moveTarget;
    protected override void FixedUpdate()
    {
        this.GetMovePosition();
        base.FixedUpdate();
    }
    protected override void ResetValue()
    {
        this.SetSpeed(speed);
        Debug.LogWarning(transform.name + ": ResetValue" + gameObject);
    }
    protected virtual void GetMovePosition()
    {
        this.targetPosition = this.transform.parent.position + transform.right * this.speed;
        this.targetPosition.z = 0;
        
    }
}

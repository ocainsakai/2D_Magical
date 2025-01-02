using UnityEngine;

public class ObjLookAtTarget : MyMonoBehaviour
{
    [Header("Look At Target")]
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float rotSpeed = 3f;

    protected virtual void FixedUpdate()
    {
        this.Looking();
    }

    protected virtual void Looking()
    {
        Vector3 dir = this.targetPosition - transform.parent.position;
        dir.Normalize();
        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        // Tính góc mục tiêu từ hướng
        float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Tạo Quaternion mục tiêu
        Quaternion targetRot = Quaternion.Euler(0, 0, targetAngle);
        transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, targetRot ,timeSpeed);
    }
    public virtual void SetRotSpeed(float speed)
    {
        this.rotSpeed = speed;
    }

}

using UnityEngine;

public class ObjLookAtCenterCamera : MyMonoBehaviour
{
    [SerializeField] protected float minCamPos = -1.6f;
    [SerializeField] protected float maxCamPos = 1.6f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }
   
    protected virtual void GetFlyDirection()
    {
        Vector3 targetPosition = GameCtrl.Instance.MainCamera.transform.position;
        Vector3 objPos = transform.parent.position;
        targetPosition.x += Random.Range(this.minCamPos, this.maxCamPos);
        targetPosition.y += Random.Range(this.minCamPos, this.maxCamPos);

        
        Vector3 diff = targetPosition - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

    }
}

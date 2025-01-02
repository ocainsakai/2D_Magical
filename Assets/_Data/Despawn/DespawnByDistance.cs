using UnityEngine;

public class DespawnByDistance : Despawn
{

    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam => GameCtrl.Instance.MainCamera.transform;
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}

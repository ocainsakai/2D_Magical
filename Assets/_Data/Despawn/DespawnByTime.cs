using UnityEngine;

public class DespawnByTime : Despawn
{

    [SerializeField] protected float timeDestroy = 70f;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected Transform mainCam => GameCtrl.Instance.MainCamera.transform;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;
        if (this.timer > this.timeDestroy) return true;
        return false;
    }
}

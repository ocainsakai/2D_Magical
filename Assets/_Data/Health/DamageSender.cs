using UnityEngine;

public class DamageSender : MyMonoBehaviour
{
    [SerializeField] protected double damage = 1f;

    public virtual void Send(Transform obj)
    {

        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {

        damageReceiver.Deduct(this.damage);
        //Debug.Log(transform.name + ": Send " + damage, gameObject);
    }


    public virtual void SetDamage(double damage)
    {

        this.damage = damage;
    }
}

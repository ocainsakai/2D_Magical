using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public abstract class CtrlTemplate : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rigidbody => rb;
    [SerializeField] protected Collider2D sphereCollider;
    public Collider2D SphereCollider => sphereCollider;

    protected virtual void Reset()
    {
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadRigibody()
    {
        if (rb != null)
        {
            return;
        }
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.bodyType = RigidbodyType2D.Kinematic;
    }
    protected virtual void LoadCollider()
    {
        if (sphereCollider != null)
        {
            return;
        }
        this.sphereCollider = GetComponent<Collider2D>();
        this.sphereCollider.isTrigger = true;

    }
}

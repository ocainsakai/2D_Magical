using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class LoadPhysicElement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rigidbody => rb;
    [SerializeField] private Collider2D _collider;
    public Collider2D Collider => _collider;

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
        if (_collider != null)
        {
            return;
        }
        this._collider = GetComponent<Collider2D>();
        this._collider.isTrigger = true;

    }
}

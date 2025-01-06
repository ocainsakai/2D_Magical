using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public abstract class CtrlBase : MonoBehaviour
{
    [SerializeField] protected SpawnerBase spawner;

    public SpawnerBase Spawner => spawner;
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rigidbody => rb;
    [SerializeField] protected Collider2D sphereCollider;
    public Collider2D SphereCollider => sphereCollider;

    protected virtual void Reset()
    {
        this.LoadCollider();
        this.LoadRigibody();
    }
    public void SetSpawner(SpawnerBase spawner)
    {
        this.spawner = spawner;
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

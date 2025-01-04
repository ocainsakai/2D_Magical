using UnityEngine;

public class MoveToPlayer : MyMonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected int speed = 1;

    protected virtual void Start()
    {
        
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();

    }

    protected virtual void LoadTarget()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": Load Target", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        if (this.player != null)
        {
            Vector3 targetPosition = player.position;
            targetPosition.z = this.transform.position.z;
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.fixedDeltaTime * speed);
        }
    }
}

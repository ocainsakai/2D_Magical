using UnityEngine;

public class MoveToPlayer : MoveToTarget<Transform>
{
    
    protected virtual void Start()
    {
        PlayerMovement playerMovement = target.GetComponent<PlayerMovement>();
        playerMovement.OnMoving += OnPlayerMove;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();

    }

    protected virtual void LoadTarget()
    {
        Transform Target = GameObject.FindGameObjectWithTag("Player").transform;
        SetTarget(Target);
        Debug.Log(transform.name + ": Load Target", gameObject);
    }

    protected virtual void OnPlayerMove()
    {
        this.Move();
    }
}

using UnityEngine;

public class PlayerMovement : LoadCtrl<PlayerCtrl>
{
    
    [SerializeField] protected float speed = 1f;


  
    protected void Start()
    {
        InputManager.OnMove += Moving;
    }

    protected virtual void Moving(Vector2 input)
    {
        this.Ctrl.Rigidbody.linearVelocity = input * speed;
    }
}

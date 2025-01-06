using UnityEngine;

public class PlayerMovement : LoadCtrl<PlayerCtrl>
{
    
    [SerializeField] protected float speed = 1f;


    public System.Action OnMoving;
  
    protected void Start()
    {
        InputManager.OnMove += Moving;
    }

    protected virtual void Moving(Vector2 input)
    {
        OnMoving?.Invoke();
        this.ctrl.Rigidbody.linearVelocity = input * speed;
    }
}

using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D Rigidbody2D;
    [SerializeField] protected float speed = 1f;


    public System.Action OnMoving;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigibody();   
    }

    protected virtual void LoadRigibody()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        //Rigidbody2D.gravityScale = 0f;
        Debug.Log(transform.name + "Load Rigibody", gameObject);
    }
    protected void Start()
    {
        InputManager.OnMove += Moving;
    }

    protected virtual void Moving(Vector2 input)
    {
        OnMoving?.Invoke();
        Rigidbody2D.linearVelocity = input * speed;
    }
}

using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] public static InputManager Instance { get; private set; }
    public static System.Action<Vector3> OnRightClick;
    public static System.Action<Vector3> OnFire;
    public static System.Action<Vector2> OnMove;

    [SerializeField] public Vector3 MouseWorldPos => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    protected virtual void Awake()
    {
        if (InputManager.Instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.Instance = this;
    }
    protected virtual void GetMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnRightClick?.Invoke(MouseWorldPos);
        }
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            OnFire?.Invoke(MouseWorldPos);
        }
    }

    protected virtual void GetMoving()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        OnMove?.Invoke(new Vector2(horizontalInput,verticalInput));
       
    }
    protected virtual void Update()
    {
        this.GetMoving();
    }
    protected virtual void FixedUpdate()
    {
        this.GetMouseDown();

    }
}

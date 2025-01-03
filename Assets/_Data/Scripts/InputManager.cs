using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance   => _instance; 

    [SerializeField] protected Vector3 _mouseWorldPos;
    public Vector3 MouseWorldPos  => _mouseWorldPos;

    public static System.Action<Vector3> OnRightClick;
    private void Awake()
    {
        if (InputManager._instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager._instance = this;
    }

    protected virtual void GetMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetMousePos();
            OnRightClick?.Invoke(this.MouseWorldPos);
            Debug.Log(transform.name + " Get mouse down");
        }

    }
    //public static void DebugHandlers()
    //{
    //    if (OnRightClick != null)
    //    {
    //        foreach (var handler in OnRightClick.GetInvocationList())
    //        {
    //            Debug.Log($"Handler đã đăng ký: {handler.Method.Name} thuộc class {handler.Target}");
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("Không có handler nào được đăng ký với OnRightClick.");
    //    }
    //}
    void Update()
    {
        this.GetMouseDown();

        //this.GetDirectionByKeyDsown();
    }

    protected virtual void GetMousePos()
    {
        this._mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

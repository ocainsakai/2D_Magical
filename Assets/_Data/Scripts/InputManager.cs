using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance   => _instance; 

    public static System.Action<Vector3> OnRightClick;
    public static System.Action<Vector3> OnFire;
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
            OnRightClick?.Invoke(GetMousePos());
        }
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            OnFire?.Invoke(GetMousePos());
        }
    }
   
    void Update()
    {
        this.GetMouseDown();

        //this.GetDirectionByKeyDsown();
    }

    protected virtual Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get => _instance; }

    [SerializeField] protected Vector3 _mouseWorldPos;
    public Vector3 MouseWorldPos  => _mouseWorldPos;

    [SerializeField ] protected float _onFiring;

    public float OnFiring => _onFiring;
    private void Awake()
    {
        if (InputManager._instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager._instance = this;
    }

    protected virtual void GetMouseDown()
    {
        this._onFiring = Input.GetAxis("Fire1");
        //Debug.Log(transform.name+ ": GetMouseDown " +_onFiring);
    }
    void Update()
    {
        this.GetMouseDown();
        //this.GetDirectionByKeyDsown();
    }
    void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this._mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

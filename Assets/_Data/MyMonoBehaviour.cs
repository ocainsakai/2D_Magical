using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        // override
    }

    protected virtual void ResetValue()
    {
        // ovirride
    }

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {

    }
}

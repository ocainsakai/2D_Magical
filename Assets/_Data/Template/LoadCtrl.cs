using UnityEngine;
[SerializeField]
public class LoadCtrl<T> : MonoBehaviour where T : CtrlBase
{
    [SerializeField] protected T ctrl;
    public T Ctrl => ctrl;
    protected virtual void Reset()
    {
        this.LoadControl();
    }   

    protected virtual void LoadControl()
    {
        if (ctrl != null)
        {
            return;
        }
        this.ctrl = transform.parent.GetComponent<T>();
    }
}

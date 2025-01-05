using UnityEngine;

public class PlayerAbstract : MonoBehaviour
{
    [SerializeField] protected PlayerCtrl ctrl;
    public PlayerCtrl PlayerCtrl => ctrl;
    protected virtual void Reset()
    {
        this.LoadCtrl();
    }   

    protected virtual void LoadCtrl()
    {
        if (ctrl != null)
        {
            return;
        }
        this.ctrl = transform.parent.GetComponent<PlayerCtrl>();
    }
}

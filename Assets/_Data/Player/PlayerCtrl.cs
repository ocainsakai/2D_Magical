using UnityEngine;
[RequireComponent (typeof(CircleCollider2D))]
public class PlayerCtrl : CtrlTemplate
{
    [SerializeField] protected Level level;
    public Level Level => level;
    protected override void Reset()
    {
        base.Reset();
        this.LoadLevel();
    }

    protected virtual void LoadLevel()
    {
        if (level == null)
        {
            this.level = this.GetComponentInChildren<Level>();
        }
    }
}

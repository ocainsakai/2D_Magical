using UnityEngine;

public class InfinityBackground : MyMonoBehaviour
{
    [SerializeField] protected Transform center;
    [SerializeField] protected Transform next;
    [SerializeField] protected int width = 1000;
    [SerializeField] protected float scale = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBackground();
    }

    protected virtual void LoadBackground()
    {
        center = transform.Find("center");
        center.transform.localScale = new Vector3 (scale, scale, scale);
        
        
        next = transform.Find("next");
        next.transform.localScale = new Vector3 (scale,scale, scale);
        
    }

    protected virtual void SetUp(Dir dir)
    {
        switch (dir)
        {   
            case Dir.up:
                next.position = center.position + Vector3.up * width * scale;
                break;
            case Dir.down:
                next.position = center.position + Vector3.down * width * scale;
                break;
            case Dir.right:
                next.position = center.position + Vector3.right * width * scale;
                break;
            case Dir.left:
                next.position = center.position + Vector3.left * width * scale;
                break;
            default:
                break;
        }
    }

}
public enum Dir
{
    up, down, right, left
}

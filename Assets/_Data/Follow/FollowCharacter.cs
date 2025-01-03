using UnityEngine;

public class FollowCharacter : FollowTransformTarget
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacter();

    }

    protected virtual void LoadCharacter()
    {
         if (this.target != null) return;
        this.target = GameObject.Find("Character").transform;
        Debug.LogWarning(transform.name + ": LoadTarget", gameObject);
    }

}

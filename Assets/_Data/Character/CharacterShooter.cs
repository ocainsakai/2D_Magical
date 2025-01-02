using UnityEngine;

public class CharacterShooter : ObjShooter
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }
}

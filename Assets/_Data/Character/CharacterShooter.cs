using UnityEngine;

public class CharacterShooter : ObjShooter
{
    protected override void Start()
    {
        InputManager.OnFire += Shoot; // Đăng ký sự kiện
    }

    protected virtual void OnDestroy()
    {
        InputManager.OnFire -= Shoot; // Hủy đăng ký sự kiện
    }

}

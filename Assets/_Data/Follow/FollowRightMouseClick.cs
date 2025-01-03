using UnityEngine;

public class FollowRightMouseClick : FollowPositionTarget
{
    protected override void Start()
    {
        InputManager.OnRightClick += MoveToTarget; // Đăng ký sự kiện
    }

    protected virtual void OnDestroy()
    {
        InputManager.OnRightClick -= MoveToTarget; // Hủy đăng ký sự kiện
    }
}

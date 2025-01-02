using Unity.VisualScripting;
using UnityEngine;

public class ObjLookAtMousePos : ObjLookAtTarget
{
    protected override void FixedUpdate()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        base.FixedUpdate();
    }
}

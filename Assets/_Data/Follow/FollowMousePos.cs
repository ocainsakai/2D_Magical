using UnityEngine;

public class FollowMousePos : MyMonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    protected virtual void FixedUpdate()
    {
        Vector3 newPos = InputManager.Instance.MouseWorldPos;
        newPos.z = 0f;
        this.transform.parent.position = Vector3.Lerp(this.transform.position, newPos, Time.fixedDeltaTime * speed);
    }
}

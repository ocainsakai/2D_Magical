using UnityEngine;

public abstract class FollowPositionTarget : MyMonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    private Coroutine currentMoveCoroutine; // Lưu trữ coroutine hiện tại

    protected virtual void MoveToTarget(Vector3 targetPosition)
    {
        // Nếu đã có một coroutine đang chạy, dừng nó
        if (currentMoveCoroutine != null)
        {
            StopCoroutine(currentMoveCoroutine);
        }

        // Bắt đầu coroutine mới để di chuyển nhân vật
        currentMoveCoroutine = StartCoroutine(MoveCharacter(targetPosition));
    }

    protected virtual System.Collections.IEnumerator MoveCharacter(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.parent.position, targetPosition) > 0.1f)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.parent.position, targetPosition, speed * Time.deltaTime);
            newPos.z = 0f;
            transform.parent.position = newPos;
            yield return null; // Đợi đến frame tiếp theo
        }

        transform.parent.position = targetPosition; // Đảm bảo vị trí cuối chính xác
        currentMoveCoroutine = null; 
    }
}

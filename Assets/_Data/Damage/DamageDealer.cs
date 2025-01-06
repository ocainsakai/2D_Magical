using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Damage Dealer")]
    public int damageAmount = 10; // Lượng sát thương gây ra

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem đối tượng có thể nhận sát thương hay không
        DamageReceiver receiver = collision.GetComponent<DamageReceiver>();
        if (receiver != null)
        {
            receiver.TakeDamage(damageAmount); // Gây sát thương
            //Destroy(gameObject); // Tùy chọn: Hủy đối tượng này (ví dụ: đạn biến mất sau khi va chạm)
        }
    }
}

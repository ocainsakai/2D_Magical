using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public int maxHealth = 100; // Máu tối đa
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Khởi tạo máu
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Giảm máu
        Debug.Log($"{gameObject.name} nhận {damage} sát thương. Máu còn lại: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // Xử lý khi máu bằng 0
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} đã chết.");
        Destroy(gameObject); // Hủy đối tượng hoặc thực hiện logic khác
    }
}

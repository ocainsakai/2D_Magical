using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
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
        if (currentHealth <= 0)
        {
            Die(); // Xử lý khi máu bằng 0
        }
    }

    protected abstract void Die();
}

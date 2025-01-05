using UnityEngine;

public class PlayerMeleeAttack : DamageDealer
{
    [Header("Player Melee Attack")]
    public float attackRange = 1f; // Phạm vi tấn công
    public LayerMask enemyLayer; // Layer của kẻ thù
    public Transform attackPoint; // Vị trí phát động đòn tấn công

    protected virtual void Start()
    {
        InputManager.OnFire += Attack;
    }
    private void Attack()
    {
        Debug.Log($"Attack");

        // Tìm tất cả các đối tượng trong phạm vi tấn công
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Gây sát thương cho từng kẻ thù trong danh sách
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log($"Đánh trúng {enemy.name}");
            DamageReceiver damageReceiver = enemy.GetComponentInChildren<DamageReceiver>();
            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(damageAmount);
            }
        }
        //Debug.Log(transform.name + "Attack", gameObject);
    }

    // Hiển thị phạm vi tấn công trong Scene View
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

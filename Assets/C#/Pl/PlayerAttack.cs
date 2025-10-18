using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 10f;
    private int enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                // UPDATED: Pass the attacker's position
                enemy.TakeDamage(attackDamage, transform.position);
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    private bool canTakeDamage = true;

    private Animator anim;

    // UI / GameOver refs
    public HealthBar healthBar;       // ลากออบเจ็ก HealthBar ลงใน Inspector
    public GameOverUI gameOverUI;     // ลากออบเจ็ก GameOverUI (panel) ลงใน Inspector

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        health = maxHealth;

        // ตั้งค่าเริ่มต้นให้ UI (ถ้ามี)
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(health);
        }
    }

    // เรียกเมื่อโดนโจมตี
    public void TakeDamage(float damage)
    {
        if (!canTakeDamage)
        {
            return;
        }

        health -= damage;
        if (health < 0) health = 0;

        anim.SetBool("Damage", true);

        // อัพเดต UI
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            // ปิด collider / ควบคุม และแจ้งตาย
            var poly = GetComponent<PolygonCollider2D>();
            if (poly != null) poly.enabled = false;

            var gather = GetComponentInParent<GatherInput>();
            if (gather != null) gather.DisableControls();

            Debug.Log("Player is dead");

            // แสดง Game Over (ถ้ามี)
            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }
        }

        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            canTakeDamage = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }
}

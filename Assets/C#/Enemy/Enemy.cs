using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float helth;

    protected Rigidbody2D rb;
    protected Animator anim;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(float damage, Vector3 attackerPosition)
    {
        helth -= damage;

        if (helth <= 0)
        {
          
            Die();
        }
        else
        {
            
            anim.SetBool("Damage", true);
            StartCoroutine(ResetDamageAnimation());

            // Knockback
            EnemyRedDog redDog = GetComponent<EnemyRedDog>();
            if (redDog != null)
            {
                redDog.KnockBack(attackerPosition);
            }
        }
    }

    private IEnumerator ResetDamageAnimation()
    {
        yield return new WaitForSeconds(0.15f);
        anim.SetBool("Damage", false);
    }

  
    void Die()
    {
        
        if (anim != null)
        {
            anim.enabled = false;
        }

       
        var colliders = GetComponents<Collider2D>();
        foreach (var col in colliders)
        {
            col.enabled = false;
        }

        if (rb != null)
        {
            rb.gravityScale = 12; 
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15f);
        }


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedDog : Enemy 
{

    public float speed = 1;
    private int direction = -1;

    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerToCheck;

    private bool detectGround;
    private bool detectWall;
    public float radius;

    public float knockbackForceX = 5f;
    public float knockbackForceY = 3f;
    public float knockbackDuration = 0.2f;
    private bool isKnockedBack = false; 

    private void FixedUpdate()
    {
        
        if (isKnockedBack || helth <= 0)
        {
            return;
        }

        Filp();
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    
    private void Filp()
    {
        detectGround = Physics2D.OverlapCircle(groundCheck.position, radius, layerToCheck);
        detectWall = Physics2D.OverlapCircle(wallCheck.position, radius, layerToCheck);

        if (!detectGround || detectWall)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }


    public void KnockBack(Vector3 attackerPosition)
    {
        if (helth <= 0 || isKnockedBack) return;

        StartCoroutine(PerformKnockback(attackerPosition));
    }

    private IEnumerator PerformKnockback(Vector3 attackerPosition)
    {
        isKnockedBack = true;

        
        int knockBackDirection = (transform.position.x < attackerPosition.x) ? -1 : 1;

        rb.linearVelocity = Vector2.zero; 

        Vector2 theForce = new Vector2(knockbackForceX * knockBackDirection, knockbackForceY);
        rb.AddForce(theForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        isKnockedBack = false;
   
        if (helth > 0)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
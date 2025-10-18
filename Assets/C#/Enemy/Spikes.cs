using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage = 10f;

    
    public float forceX = 5f;
    public float forceY = 5f;
    public float duration = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerStats"))
        {
            Debug.Log("Player hit by spikes");
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            playerStats.TakeDamage(damage);

            PlayerMoveControls pmc = playerStats.GetComponentInParent<PlayerMoveControls>();
            if (pmc != null)
            {
                StartCoroutine(pmc.KnockBack(forceX, forceY, duration, transform));
            }
        }
    }
}

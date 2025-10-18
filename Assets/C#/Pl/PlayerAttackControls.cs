using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    private PlayerMoveControls playerMoveControls;
    private GatherInput gatherInput;
    private Animator animator;

    public PolygonCollider2D attackCollider;

    public bool attackStarted = false;

    public AudioSource audioSource;
    void Start()
    {
        playerMoveControls = GetComponent<PlayerMoveControls>();
        gatherInput = GetComponent<GatherInput>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {

        if (animator.GetBool("Damage") || animator.GetBool("Death"))
        {
            return;
        }
        //if player presses the attack button
        if (gatherInput.tryAttack)
        {
            animator.SetBool("Attack", true);
            attackStarted = true;
        }
    }

    public void ResetAttack()
    {
        // set the attack animation to false
        animator.SetBool("Attack", false);
        gatherInput.tryAttack = false;
        attackStarted = false;
        attackCollider.enabled = false;
    }

    public void ActivateAttack()
    {
        attackCollider.enabled = true;
        audioSource.Play();
    }

}

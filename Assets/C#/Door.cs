using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    public int levelToLoad;
    public Animator animator;
    public string openTrigger = "Open";
    public float waitTime = 0f;

    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        boxCollider.enabled = false;
        other.GetComponent<GatherInput>()?.DisableControls();
        animator?.SetTrigger(openTrigger);
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        float delay = waitTime > 0f ? waitTime : GetAnimationLength();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(levelToLoad);
    }

    private float GetAnimationLength()
    {
        if (animator == null || animator.runtimeAnimatorController == null)
            return 0.5f;

        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name.ToLower().Contains(openTrigger.ToLower()))
                return clip.length;
        }

        return 0.5f;
    }
}

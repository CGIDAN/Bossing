using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    public string[] animationNames; // Names of the animations to play in a rotation
    private int currentIndex = 0; // Index of the current animation being played
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("AnimationIndex", currentIndex); // Start with the first animation
    }

    private void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Idle"))
        {
            // Reset the animation index if we've returned to the "Idle" animation
            currentIndex = 0;
            animator.SetInteger("AnimationIndex", currentIndex);
        }
        else if (stateInfo.normalizedTime >= 1.0f) // If the current animation has finished playing
        {
            currentIndex++;
            if (currentIndex >= animationNames.Length) // If we've played all the animations in the array, start over
            {
                currentIndex = 0;
            }
            animator.SetInteger("AnimationIndex", currentIndex); // Set the "AnimationIndex" parameter to the new index
        }
    }
}

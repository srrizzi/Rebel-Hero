using UnityEngine;

public class AnimationWarrior : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private Warrior warrior;

    void Update()
    {
        float speedY = this.rigidbody.linearVelocityY;
        float speedX = Mathf.Abs(this.rigidbody.linearVelocityX);

        if (this.warrior.OnTheGround)
        {
            this.animator.SetBool("isJumping", false);
            this.animator.SetBool("isFalling", false);

            if (speedX > 0)
            {
                this.animator.SetBool("isRunning", true);
            }
            else
            {
                this.animator.SetBool("isRunning", false);
            }
        }
        else
        {
            this.animator.SetBool("isRunning", false);

            if (speedY > 0)
            {
                this.animator.SetBool("isJumping", true);
                this.animator.SetBool("isFalling", false);
            }
            else if (speedY < 0)
            {
                this.animator.SetBool("isJumping", false);
                this.animator.SetBool("isFalling", true);
            }
        }
    }
}

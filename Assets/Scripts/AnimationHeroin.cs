using UnityEngine;

public class AnimationHeroin : MonoBehaviour
{
  [SerializeField]
  private Animator animator;

  [SerializeField]
  private Rigidbody2D rigidbody;

  [SerializeField]
  private Heroin heroin;

  private bool isAttacking;

  void Update()
  {
    float speedY = rigidbody.linearVelocityY;
    float speedX = Mathf.Abs(rigidbody.linearVelocityX);

    if (isAttacking)
    {
      this.animator.SetBool("isAttacking", true);
    }
    else
    {
      this.animator.SetBool("isAttacking", false);
    }

    if (heroin.OnTheGround)
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

  public void TriggerAttackAnimation()
  {
    isAttacking = true;
    Invoke(nameof(ResetAttack), 0.5f);
  }

  private void ResetAttack()
  {
    isAttacking = false;
  }
}

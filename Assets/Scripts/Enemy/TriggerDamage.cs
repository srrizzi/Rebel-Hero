using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
  public HeartSystem heart;
  public Heroin heroin;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      heroin.kBCount = heroin.kBTime;
      if(collision.transform.position.x <= transform.position.x)
      {
        heroin.isKnockRight = true;
      }
      if (collision.transform.position.x > transform.position.x)
      {
        heroin.isKnockRight = false;
      }
      heart.Life -= 1;
      heroin.anim.SetTrigger("TakeDamage");
    }
  }
}

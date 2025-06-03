using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
  public HeartSystem heart;
  public Heroin heroin;

  AudioManager audioManager;

  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      audioManager.PlaySFX(audioManager.damage);

      heroin.kBCount = heroin.kBTime;
      if(collision.transform.position.x <= transform.position.x)
      {
        heroin.isKnockRight = true;
      }
      if (collision.transform.position.x > transform.position.x)
      {
        heroin.isKnockRight = false;
      }
      heart.Life--;
      heroin.anim.SetTrigger("TakeDamage");
    }
  }
}

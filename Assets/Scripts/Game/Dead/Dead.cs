using UnityEngine;

public class Dead : MonoBehaviour
{
  [SerializeField] private Collider2D collider2D;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
    //  collider2D.enabled = false;
      collision.GetComponent<HeartSystem>().TakeDamage(1);
      collision.GetComponent<Heroin>().enabled = false;
      collision.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
  }
}

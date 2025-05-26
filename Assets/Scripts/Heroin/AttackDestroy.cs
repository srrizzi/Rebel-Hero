using UnityEngine;

public class AttackDestroy : MonoBehaviour
{
  public bool isPowerUp = false;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PowerUpRed();
    }
  }

  private void PowerUpRed()
  {
    isPowerUp = true;
    Destroy(gameObject);
  }
}

using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
  public Transform respawnPoint;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      // Respawn
      collision.transform.position = respawnPoint.position;

      // Aplica dano
      HeartSystem heartSystem = collision.GetComponent<HeartSystem>();
      if (heartSystem != null)
      {
        heartSystem.TakeDamage(1);
      }
    }
  }
}

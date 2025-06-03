using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
  public Transform respawnPoint;

  AudioManager audioManager;

  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      audioManager.PlaySFX(audioManager.damage);

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

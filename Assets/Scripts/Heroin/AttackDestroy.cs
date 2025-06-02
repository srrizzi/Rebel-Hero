using UnityEngine;

public class AttackDestroy : MonoBehaviour
{
  public bool isPowerUp = false;

  AudioManager audioManager;
    private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PowerUpRed();
      audioManager.PlaySFX(audioManager.powerUpRed);
    }
  }

  private void PowerUpRed()
  {
    isPowerUp = true;
    Destroy(gameObject);
  }
}

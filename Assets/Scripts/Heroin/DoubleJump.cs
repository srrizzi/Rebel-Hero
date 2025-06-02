using UnityEngine;

public class DoubleJump : MonoBehaviour
{
  public bool isDoubleJump = false;
  AudioManager audioManager;
  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PowerUpBlue();
      audioManager.PlaySFX(audioManager.powerUpBlue);
    }
  }

  private void PowerUpBlue()
  {
    isDoubleJump = true;
    Destroy(gameObject);
  }
}

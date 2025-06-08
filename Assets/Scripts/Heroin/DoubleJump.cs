using UnityEngine;
using UnityEngine.SceneManagement;

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

      if (SceneManager.GetActiveScene().name != "Cave" && SceneManager.GetActiveScene().name != "Boss")
      {
        audioManager.PlaySFX(audioManager.powerUpBlue);
      }
    }
  }

  private void PowerUpBlue()
  {
    isDoubleJump = true;
    Destroy(gameObject);
  }
}

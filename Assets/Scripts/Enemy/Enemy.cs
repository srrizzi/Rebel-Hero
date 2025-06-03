using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] private int health;

  AudioManager audioManager;
  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }

  public void TakeDamage()
  {
    if (CompareTag("Slime"))
    {
      audioManager.PlaySFX(audioManager.enemySlime);
    }
    else if (CompareTag("Fly"))
    {
      audioManager.PlaySFX(audioManager.enemyFly);
    }
    else if (CompareTag("Hand"))
    {
      audioManager.PlaySFX(audioManager.enemyHand);
    }
    else if (CompareTag("Shadow"))
    {
      audioManager.PlaySFX(audioManager.enemyShadow);
    }

    health--;
    Debug.Log("Health: " + health);
    if (health == 0)
    {
      Destroy(gameObject, 0.1f);
      Debug.Log("Enemy destroyed");
    }
  }
}

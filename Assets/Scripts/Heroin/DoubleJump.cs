using UnityEngine;

public class DoubleJump : MonoBehaviour
{
  public bool isDoubleJump = false;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PowerUpBlue();
    }
  }

  private void PowerUpBlue()
  {
    isDoubleJump = true;
    Destroy(gameObject);
  }
}

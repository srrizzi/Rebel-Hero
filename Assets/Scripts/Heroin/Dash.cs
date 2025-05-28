using UnityEngine;

public class Dash : MonoBehaviour
{
  public bool isDash = false;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PowerUpPurple();
    }
  }

  private void PowerUpPurple()
  {
    isDash = true;
    //Destroy(gameObject);
  }
}

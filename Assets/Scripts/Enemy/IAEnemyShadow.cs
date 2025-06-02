using UnityEngine;

public class IAEnemyShadow : MonoBehaviour
{
  public float moveSpeed = 2f;
  public float patrolDistance = 3f;

  private Vector2 initialPosition;
  private bool movingRight = true;
  private SpriteRenderer spriteRenderer;

  //AudioManager audioManager;

  //private void Awake()
  //{
  //  audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  //}

  void Start()
  {
    initialPosition = transform.position;
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
  }

  void Update()
  {
    Patrol();
  }

  void Patrol()
  {
    float distanceFromStart = transform.position.x - initialPosition.x;

    if (movingRight)
    {
      transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
      spriteRenderer.flipX = true;
      if (distanceFromStart >= patrolDistance)
        movingRight = false;
    }
    else
    {
      transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
      spriteRenderer.flipX = false;
      if (distanceFromStart <= -patrolDistance)
        movingRight = true;
    }
  }
}

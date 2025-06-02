using UnityEngine;

public class IAEnemyHand : MonoBehaviour
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
      spriteRenderer.flipX = false; // Indo para a direita, flipX deve ser falso
      if (distanceFromStart >= patrolDistance)
        movingRight = false;
    }
    else
    {
      transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
      spriteRenderer.flipX = true; // Indo para a esquerda, flipX deve ser verdadeiro
      if (distanceFromStart <= -patrolDistance)
        movingRight = true;
    }
  }
}

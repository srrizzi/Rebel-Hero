using UnityEngine;

public class IAEnemyHand : MonoBehaviour
{
  public Transform player;
  public float detectionRange = 5f;
  public float attackRange = 1f;
  public float moveSpeed = 2f;
  public float patrolDistance = 3f;

  private Vector2 initialPosition;
  private bool movingRight = true;
  private Rigidbody2D rb;

  void Start()
  {
    initialPosition = transform.position;
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    // Check if player reference is valid before accessing it
    if (player == null)
      return;

    float distanceToPlayer = Vector2.Distance(transform.position, player.position);

    if (distanceToPlayer < detectionRange && IsWithinPatrolLimits(player.position))
    {
      // Persegue o jogador no eixo X
      Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
      transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
    else
    {
      // Patrulha
      Patrol();
    }
  }

  void Patrol()
  {
    float distanceFromStart = transform.position.x - initialPosition.x;

    if (movingRight)
    {
      transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
      if (distanceFromStart >= patrolDistance)
        movingRight = false;
    }
    else
    {
      transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
      if (distanceFromStart <= -patrolDistance)
        movingRight = true;
    }
  }

  bool IsWithinPatrolLimits(Vector2 targetPosition)
  {
    float relativeX = targetPosition.x - initialPosition.x;
    return relativeX >= -patrolDistance && relativeX <= patrolDistance;
  }
}

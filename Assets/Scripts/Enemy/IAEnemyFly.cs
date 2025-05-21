using UnityEngine;

public class IAEnemyFly : MonoBehaviour
{
  public Transform player;
  public float detectionRange = 5f;
  public float attackRange = 1f;
  public float moveSpeed = 2f;
  public float patrolDistance = 3f;

  private Vector2 initialPosition;
  private bool movingRight = true;

  void Start()
  {
    initialPosition = transform.position;
  }

  void Update()
  {
    float distanceToPlayer = Vector2.Distance(transform.position, player.position);

    if (distanceToPlayer < detectionRange)
    {
      // Persegue o jogador
      Vector2 direction = (player.position - transform.position).normalized;
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

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      // Dá dano aqui
      Debug.Log("Player atingido!");
      // Aqui você pode chamar o método de dano do jogador
    }
  }
}

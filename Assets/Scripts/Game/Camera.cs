using UnityEngine;

public class Camera : MonoBehaviour
{
  [SerializeField]
  private Transform player;

  [SerializeField]
  private float moveSpeed;

  [SerializeField]
  private bool moveX;

  [SerializeField]
  private bool moveY;

  [SerializeField]
  private Vector2 offset;

  [SerializeField]
  private float horizontalThreshold = 35.0f;

  [SerializeField]
  private float minX;

  private float leftLimit;  // Limite esquerdo da câmera
  private float rightLimit; // Limite direito da câmera

  void Start()
  {
    // Inicializa os limites com base na posição inicial do jogador
    UpdateLimits();
  }

  void LateUpdate()
  {
    Vector3 finalPosition = transform.position;

    // Verifica se a câmera deve se mover no eixo X
    if (moveX)
    {
      if (player.position.x < leftLimit) // Jogador ultrapassou o limite esquerdo
      {
        finalPosition.x = Mathf.Lerp(transform.position.x, player.position.x + offset.x, moveSpeed * Time.deltaTime);
        UpdateLimits(); // Atualiza os limites
      }
      else if (player.position.x > rightLimit) // Jogador ultrapassou o limite direito
      {
        finalPosition.x = Mathf.Lerp(transform.position.x, player.position.x + offset.x, moveSpeed * Time.deltaTime);
        UpdateLimits(); // Atualiza os limites
      }

      // Limita a posição da câmera ao início da fase
      finalPosition.x = Mathf.Max(finalPosition.x, minX);
    }

    // Verifica se a câmera deve se mover no eixo Y
    if (moveY)
    {
      finalPosition.y = Mathf.Lerp(transform.position.y, player.position.y + offset.y, moveSpeed * Time.deltaTime);
    }

    // Mantém a posição Z da câmera
    finalPosition.z = transform.position.z;

    // Atualiza a posição da câmera
    transform.position = finalPosition;
  }

  private void UpdateLimits()
  {
    // Atualiza os limites esquerdo e direito com base na posição atual do jogador
    leftLimit = player.position.x - horizontalThreshold;
    rightLimit = player.position.x + horizontalThreshold;
  }
}

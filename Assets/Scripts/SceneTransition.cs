using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
  [SerializeField]
  private string targetSceneName; // Nome da cena para onde será feita a transição

  private void OnTriggerEnter2D(Collider2D collision)
  {
    // Verifica se o objeto que colidiu tem o componente "Heroin" (o personagem)
    if (collision.GetComponent<Heroin>() != null)
    {
      // Transfere para a cena especificada
      SceneManager.LoadScene(targetSceneName);
    }
  }
}
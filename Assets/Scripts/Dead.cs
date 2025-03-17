using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MortalTile")) // Certifique-se de que o Tilemap tem essa tag
        {
            Application.Quit();
        }
    }

    void Die()
    {
        // Aqui voc� pode colocar a l�gica de morte, como reiniciar o n�vel
        Debug.Log("O jogador morreu!");
        //gameObject.SetActive(false); // Desativa o personagem
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Para reiniciar a cena
    }
}

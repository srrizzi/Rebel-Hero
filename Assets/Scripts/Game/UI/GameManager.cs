using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public GameObject gameOverUI;
  public GameObject pauseMenu;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void PauseMenu()
  {
    pauseMenu.SetActive(true);
    Time.timeScale = 0f;
  }

  public void ResumeGame()
  {
    pauseMenu.SetActive(false);
    Time.timeScale = 1f;
  }

  public void gameOver()
  {
    gameOverUI.SetActive(true);
  }

  public void RestartGame()
  {
    gameOverUI.SetActive(false);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void LoadMainMenu()
  {
    gameOverUI.SetActive(false);
    SceneManager.LoadScene("MainMenu");
  }

  public void QuitGame()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
  }
}

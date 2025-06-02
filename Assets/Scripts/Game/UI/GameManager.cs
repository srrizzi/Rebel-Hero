using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public GameObject gameOverUI;
  public GameObject pauseMenu;
  AudioManager audioManager;
  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void PauseMenu()
  {
    audioManager.PlaySFX(audioManager.buttonClick);
    pauseMenu.SetActive(true);
    Time.timeScale = 0f;
  }

  public void ResumeGame()
  {
    audioManager.PlaySFX(audioManager.buttonClick);
    pauseMenu.SetActive(false);
    Time.timeScale = 1f;
  }

  public void gameOver()
  {
    gameOverUI.SetActive(true);
  }

  public void RestartGame()
  {
    audioManager.PlaySFX(audioManager.buttonClick);
    gameOverUI.SetActive(false);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void LoadMainMenu()
  {
    audioManager.PlaySFX(audioManager.buttonClick);
    gameOverUI.SetActive(false);
    SceneManager.LoadScene("MainMenu");
  }

  public void QuitGame()
  {
    audioManager.PlaySFX(audioManager.buttonClick);
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
  }
}

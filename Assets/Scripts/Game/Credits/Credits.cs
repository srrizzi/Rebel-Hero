using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
  public string mainMenuSceneName = "MainMenu";


  void Start()
  {
    
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      LoadMainMenu();
    }
  }

  void LoadMainMenu()
  {
    SceneManager.LoadScene(mainMenuSceneName);
  }
}

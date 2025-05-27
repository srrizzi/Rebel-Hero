using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  [SerializeField] private string scenePlay;
  [SerializeField] private string sceneCredits;
  [SerializeField] private GameObject panelMenu;
  [SerializeField] private GameObject panelTutorial;
  [SerializeField] private GameObject panelAbout;
  [SerializeField] private GameObject panelOption;

  public void ButtonStart()
  {
    SceneManager.LoadScene(scenePlay);
  }

  public void OpenTutorial()
  {
    panelMenu.SetActive(false);
    panelTutorial.SetActive(true);
  }

  public void CloseTutorial()
  {
    panelTutorial.SetActive(false);
    panelMenu.SetActive(true);
  }

  public void OpenAbout()
  {
    panelMenu.SetActive(false);
    panelAbout.SetActive(true);
  }

  public void CloseAbout()
  {
    panelAbout.SetActive(false);
    panelMenu.SetActive(true);
  }

  public void OpenOption()
  {
    panelMenu.SetActive(false);
    panelOption.SetActive(true);
  }

  public void CloseOption()
  {
    panelOption.SetActive(false);
    panelMenu.SetActive(true);
  }

  public void ButtonCredits()
  {
    SceneManager.LoadScene(sceneCredits);
  }

  public void Exit()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
  }
}

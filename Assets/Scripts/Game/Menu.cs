using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelOption;

    public void ButtonStart()
    {
        SceneManager.LoadScene(sceneName);
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

  public void Exit()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
  }
}

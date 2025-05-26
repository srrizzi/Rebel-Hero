using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
  public float scrollSpeed = 80f;
  public RectTransform creditsRectTransform;
  public string mainMenuSceneName = "MainMenu"; // Set this to your main menu scene name in the Inspector

  private float screenTopY;

  void Start()
  {
    creditsRectTransform = GetComponent<RectTransform>();
    // Calculate the Y position at which the credits are fully off-screen
    float canvasHeight = creditsRectTransform.GetComponentInParent<Canvas>().GetComponent<RectTransform>().rect.height;
    screenTopY = canvasHeight + creditsRectTransform.rect.height;
  }

  void Update()
  {
    creditsRectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

    // Check if credits have scrolled past the top of the screen
    if (creditsRectTransform.anchoredPosition.y >= screenTopY)
    {
      LoadMainMenu();
    }

    // Check for Escape key press
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

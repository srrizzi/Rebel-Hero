using UnityEngine;

public class SaveLoad : MonoBehaviour
{
  [SerializeField] private Transform heroin;

  private void Start()
  {
    // Check if there is a saved scene name
    string savedScene = PlayerPrefs.GetString("currentScene", "");
    if (!string.IsNullOrEmpty(savedScene))
    {
      // Get the current scene name
      string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

      // Only load position if the current scene matches the saved scene
      if (currentScene == savedScene)
      {
        float x = PlayerPrefs.GetFloat("playerPositionX", heroin.position.x);
        float y = PlayerPrefs.GetFloat("playerPositionY", heroin.position.y);
        heroin.position = new Vector3(x, y, heroin.position.z);
      }
    }
  }

  public void Save()
  {
    PlayerPrefs.SetFloat("playerPositionX", heroin.position.x);
    PlayerPrefs.SetFloat("playerPositionY", heroin.position.y);
    PlayerPrefs.SetString("currentScene", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    PlayerPrefs.Save();
  }

  public void Load()
  {
    float loadPositionX = PlayerPrefs.GetFloat("playerPositionX", heroin.position.x);
    float loadPositionY = PlayerPrefs.GetFloat("playerPositionY", heroin.position.y);
    heroin.position = new Vector3(loadPositionX, loadPositionY, heroin.position.z);
  }
}

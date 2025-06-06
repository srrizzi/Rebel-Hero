using UnityEngine;

public class SaveLoad : MonoBehaviour
{
  [SerializeField] private Transform heroin;

  private void Start()
  {
    
  }

  private void Update()
  {
    
  }

  public void Save()
  {
    PlayerPrefs.SetFloat("playerPositionX", heroin.position.x);
    PlayerPrefs.SetFloat("playerPositionY", heroin.position.y);
  }

  public void Load()
  {
    float loadPositionX = PlayerPrefs.GetFloat("playerPositionX");
    float loadPositionY = PlayerPrefs.GetFloat("playerPositionY");
  }
}

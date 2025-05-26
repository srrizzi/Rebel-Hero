using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
  Heroin heroin;
  public int Life;
  public int MaxLife;
  public bool isDead;

  public Image[] Hearts;
  public Sprite amptyHeart;
  public Sprite fullHeart;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    heroin = GetComponent<Heroin>();
  }

  // Update is called once per frame
  void Update()
  {
    HealthLogic();
    DeadState();
  }

  void HealthLogic()
  {
    if (Life > MaxLife) Life = MaxLife;

    for (int i = 0; i < Hearts.Length; i++)
    {
      Hearts[i].sprite = (i < Life) ? fullHeart : amptyHeart;
      Hearts[i].enabled = (i < MaxLife) ? true : false;
    }
  }

  void DeadState()
  {
    if (Life <= 0)
    {
      isDead = true;
      heroin.anim.SetBool("isDead", isDead);
      GetComponent<Heroin>().enabled = false;
      Destroy(gameObject, 0.8f);
      SceneManager.LoadScene("MainMenu");
    }
  }
  public void TakeDamage(int amount = 1)
  {
    Life -= amount;
    if (Life < 0) Life = 0;
  }
}

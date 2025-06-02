using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
  #region AUDIOSURCE
  [Header("---------------Audio Source---------------")]
  [SerializeField] AudioSource musicSource;
  [SerializeField] AudioSource SFXSource;

  [Header("---------------Audio Clip Background---------------")]
  public AudioClip backgroundMenu;
  public AudioClip backgroundForest;
  public AudioClip backgroundCave;
  public AudioClip backgroundBoss;
  public AudioClip backgroundCredits;

  [Header("---------------Audio Clip UI---------------")]
  public AudioClip buttonClick;

  [Header("---------------Audio Clip SFX Heroin---------------")]
  public AudioClip footstepsForest;
  public AudioClip footstepsCave;
  public AudioClip footstepsSnow;
  public AudioClip interactNpc;
  public AudioClip jump;
  public AudioClip attack;
  public AudioClip dead;
  public AudioClip damage;

  [Header("---------------Audio Clip SFX Enemy---------------")]
  public AudioClip enemyFly;
  public AudioClip enemySlime;
  public AudioClip enemyHand;
  public AudioClip enemyShadow;

  [Header("---------------Audio Clip SFX Boss---------------")]
  public AudioClip bossAttack;
  public AudioClip bossDead;
  public AudioClip bossDamage;
  public AudioClip bossFootsteps;

  [Header("---------------Audio Clip SFX PowerUp---------------")]
  public AudioClip powerUpRed;
  public AudioClip powerUpBlue;
  public AudioClip powerUpPurple;

  [Header("---------------Audio Clip SFX NPC---------------")]
  public AudioClip npcTalk;
  public AudioClip npcSkipTalk;
  #endregion
  private void Start()
  {
    #region BACKGROUND MUSIC
    if (SceneManager.GetActiveScene().name == "MainMenu")
    {
      musicSource.clip = backgroundMenu;
      musicSource.loop = true;
      musicSource.Play();
    }
    else if (SceneManager.GetActiveScene().name == "Forest")
    {
      musicSource.clip = backgroundForest;
      musicSource.loop = true;
      musicSource.Play();
    }
    else if (SceneManager.GetActiveScene().name == "Cave")
    {
      musicSource.clip = backgroundCave;
      musicSource.loop = true;
      musicSource.Play();
    }
    else if (SceneManager.GetActiveScene().name == "Boss")
    {
      musicSource.clip = backgroundBoss;
      musicSource.loop = true;
      musicSource.Play();
    }
    else if (SceneManager.GetActiveScene().name == "Credits")
    {
      musicSource.clip = backgroundCredits;
      musicSource.loop = true;
      musicSource.Play();
    }
    #endregion
  }

  public void PlaySFX(AudioClip clip)
  {
    SFXSource.PlayOneShot(clip);
  }

}

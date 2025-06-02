using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
  [SerializeField] private string scenePlay;
  [SerializeField] private string sceneCredits;
  [SerializeField] private GameObject panelMenu;
  [SerializeField] private GameObject panelTutorial;
  [SerializeField] private GameObject panelAbout;
  [SerializeField] private GameObject panelOption;

  AudioManager audioManager;

  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }

  public void ButtonStart()
  {
    SceneManager.LoadScene(scenePlay);
    audioManager.PlaySFX(audioManager.buttonClick);
  }

  public void OpenTutorial()
  {
    panelMenu.SetActive(false);
    panelTutorial.SetActive(true);
    audioManager.PlaySFX(audioManager.buttonClick);
  }

  public void CloseTutorial()
  {
    panelTutorial.SetActive(false);
    panelMenu.SetActive(true);
    audioManager.PlaySFX(audioManager.buttonClick);
  }

  public void OpenAbout()
  {
    panelMenu.SetActive(false);
    panelAbout.SetActive(true);
    audioManager.PlaySFX(audioManager.buttonClick);
  }

  public void CloseAbout()
  {
    panelAbout.SetActive(false);
    panelMenu.SetActive(true);
    audioManager.PlaySFX(audioManager.buttonClick);
  }

  public void OpenOption()
  {
    panelMenu.SetActive(false);
    panelOption.SetActive(true);
    audioManager.PlaySFX(audioManager.buttonClick);
  }

  public void CloseOption()
  {
    panelOption.SetActive(false);
    panelMenu.SetActive(true);
    audioManager.PlaySFX(audioManager.buttonClick);
  }

  public void ButtonCredits()
  {
    SceneManager.LoadScene("Credits");
    audioManager.PlaySFX(audioManager.buttonClick);
  }

  public void Exit()
  {
    audioManager.PlaySFX(audioManager.buttonClick);
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
  }
}
